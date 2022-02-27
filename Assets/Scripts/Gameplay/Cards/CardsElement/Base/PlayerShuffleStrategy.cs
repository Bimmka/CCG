using System.Collections;
using System.Collections.Generic;
using Extensions;
using Gameplay.Table;
using Services;
using Services.Random;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class PlayerShuffleStrategy : CardUseStrategy, IMultipliedCard
  {
    private readonly Field field;
    private readonly IRandomService randomService;
    private readonly ICoroutineRunner coroutineRunner;

    public PlayerShuffleStrategy(CardStrategyStaticData data, Field field, IRandomService randomService, ICoroutineRunner coroutineRunner) : base(data, coroutineRunner)
    {
      this.field = field;
      this.randomService = randomService;
      this.coroutineRunner = coroutineRunner;
    }

    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Shuffle());
    }

    private IEnumerator Shuffle()
    {
      (List<FieldCell>, List<Card>) cellsAndCards = CollectCardsAndCellsAndDisableCard();
      yield return new WaitForSeconds(1f);
      
      cellsAndCards.Item1.Shuffle(randomService);
      SpawnCards(cellsAndCards);
      yield return new WaitForSeconds(1f);
      
      DecOperationsCount();
      if (IsOperationsEnd())
        NotifyAboutEnd();
      else
        coroutineRunner.StartCoroutine(Shuffle());
    }


    private (List<FieldCell> cells, List<Card> cards) CollectCardsAndCellsAndDisableCard()
    {
      List<FieldCell> cells = new List<FieldCell>(12);
      List<Card> cards = new List<Card>(10);

      FieldCell cell;
      int startRow = field.Size.y - field.PlayerRows - 1;
      while (startRow >= 0)
      {
        for (int i = 0; i < field.Size.x; i++)
        {
          cell = field.Cell(new Vector2Int(i, startRow));
          if (cell != null)
          {
            cells.Add(cell);
            if (cell.IsFill)
            {
              cards.Add(cell.CurrentCard);
              cell.CurrentCard.Hide();
              cell.RemoveCard();
            }
          }
        }

        startRow--;
      }

      return (cells, cards);
    }

    private void SpawnCards((List<FieldCell>, List<Card>) cellsAndCards)
    {
      for (int i = 0; i < cellsAndCards.Item2.Count; i++)
      {
        cellsAndCards.Item2[i].Mover.SetPosition(cellsAndCards.Item1[i].OffsetedYLocalPosition);
        cellsAndCards.Item1[i].SetCard(cellsAndCards.Item2[i]);
        cellsAndCards.Item2[i].Show();
      }  
    }
    public void MultiplyOperationsCount(int multiplier)
    {
      MultiplyOperations(multiplier);
    }
  }
}