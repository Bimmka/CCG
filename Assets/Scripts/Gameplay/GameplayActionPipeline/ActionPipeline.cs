using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Cards.CardsElement.Base;
using Gameplay.Cards.Hand;
using Gameplay.Cards.Spawners;
using Gameplay.Table;
using UnityEngine;

namespace Gameplay.GameplayActionPipeline
{
  public class ActionPipeline : MonoBehaviour
  {
    [SerializeField] private Field field;
    [SerializeField] private CardSpawner cardSpawner;
    [SerializeField] private GameplayPlayerHand playerHand;
    
    private readonly List<FieldCell> activatedCells = new List<FieldCell>(20);

    private bool isInterraptActions;

    public event Action Ended;

    public void SetIsInterraptActions()
    {
      isInterraptActions = true;
    }

    public void StartPipeline()
    {
      StopAllCoroutines();
      StartCoroutine(ActivateActions());
    }

    private IEnumerator ActivateActions()
    {
      yield return StartCoroutine(ActivatePlayerActions());

      yield return StartCoroutine(ActivateOpponentActions());

      DiscardPlayerHand();

      yield return StartCoroutine(WaitDestroyCards());

      yield return StartCoroutine(WaitCardMove());

      SpawnNewCards();
      
      NotifyAboutEnded();  
    }

    private IEnumerator ActivatePlayerActions()
    {
      IEnumerable<FieldCell> cells = field.PlayerRow;
      foreach (FieldCell fieldCell in cells)
      {
        if (fieldCell.IsFill && fieldCell.CurrentCard.IsActivated == false)
        {
          activatedCells.Add(fieldCell);
          fieldCell.CurrentCard.Activate();
          yield return StartCoroutine(WaitCardActivateEnd(fieldCell.CurrentCard));
        }
      }
    }

    private IEnumerator ActivateOpponentActions()
    {
      IEnumerable<FieldCell> cells = field.OpponentDownRow;
      foreach (FieldCell fieldCell in cells)
      {
        if (isInterraptActions)
        {
          NotifyAboutEnded();
          StopAllCoroutines();
          yield break;
        }
        
        if (fieldCell.IsFill && fieldCell.CurrentCard.IsActivated == false)
        {
          activatedCells.Add(fieldCell);
          fieldCell.CurrentCard.Activate();
          yield return StartCoroutine(WaitCardActivateEnd(fieldCell.CurrentCard));
        }
      }
    }

    private void DiscardPlayerHand()
    {
      playerHand.ReleaseHand();
    }

    private IEnumerator WaitDestroyCards()
    {
      for (int i = 0; i < activatedCells.Count; i++)
      {
        activatedCells[i].CurrentCard.Destroy();
      }

      while (activatedCells.Count(x => x.CurrentCard.Status == CardStatus.Destroying) > 0)
      {
        yield return null;
      }

      for (int i = 0; i < activatedCells.Count; i++)
      {
        activatedCells[i].RemoveCard();
      }
      
      activatedCells.Clear();
    }

    private IEnumerator WaitCardMove()
    {
      int rowIndex = field.FirstCommonRow;
      while (IsCorrectRow(rowIndex))
      {
        if (field.IsHaveCardInRow(rowIndex))
        {
          field.MoveCardInRowDown(rowIndex);
          yield return new WaitForSeconds(1f);
        }

        rowIndex--;
      }
    }

    private IEnumerator WaitCardActivateEnd(Card card)
    {
      while (card.Status == CardStatus.Using)
      {
        yield return null;
      }
    }

    private void SpawnNewCards()
    {
      cardSpawner.SpawnOnTopRow();
    }

    private bool IsCorrectRow(int rowIndex) => 
      rowIndex >= 0;

    private void NotifyAboutEnded()
    {
      Ended?.Invoke();
    }
  }
}