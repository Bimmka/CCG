using System;
using System.Collections;
using Gameplay.Cards.CardsElement.Base;
using Gameplay.Cards.Hand;
using Gameplay.Cards.Spawners;
using Gameplay.Table;
using StaticData.Gameplay.Cards.Elements;
using UI.Windows.PlayerHand;
using UnityEngine;

namespace Gameplay.Clicks
{
  public class PlayerClickHandler : MonoBehaviour
  {
    [SerializeField] private PlayerHandWindow handWindow;
    [SerializeField] private GameplayPlayerHand hand;
    [SerializeField] private float raycastDistance = 100f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private CardSpawner cardSpawner;
    [SerializeField] private Field field;

    private Camera mainCamera;
    private readonly RaycastHit[] hits = new RaycastHit[1];

    public bool IsCanClick { get; private set; }

    public event Action<CardStaticData> ClickedCard;
    public event Action RemovedCard;

    private void Awake()
    {
      handWindow.IsCanClicked += IsCanClicked;
      handWindow.Clicked += OnCardHandClicked;
      mainCamera = Camera.main;
    }

    private void OnDestroy()
    {
      handWindow.IsCanClicked -= IsCanClicked;
      handWindow.Clicked -= OnCardHandClicked;
    }

    public void LockClick()
    {
      IsCanClick = false;
    }

    public void UnlockCLick()
    {
      IsCanClick = true;
    }

    private bool IsCanClicked() => 
      IsCanClick;

    private void OnCardHandClicked(CardStaticData card)
    {
      StopAllCoroutines();
      StartCoroutine(ApplyingClicks(card));
      ClickedCard?.Invoke(card);

    }

    private IEnumerator ApplyingClicks(CardStaticData card)
    {
      while (gameObject.activeSelf && IsCanClick)
      {
        yield return null;
        
        if (Input.GetMouseButtonUp(1))
        {
          ReturnCard(card);
          RemovedCard?.Invoke();
          yield break;
        }
        
        if (HitCell() && hits[0].collider.TryGetComponent(out FieldCell cell))
        {
          if (Input.GetMouseButtonUp(0) && IsCanSetCardToCell(card, cell))
          {
            SetCardToCell(card, cell);
            UseCard(card);
            RemovedCard?.Invoke();
            yield break;
          }
          
          ProcessingCell(card, cell);
        }
      }
      
    }

    private void UseCard(CardStaticData card) => 
      hand.UseCard(card);

    private void ReturnCard(CardStaticData card) => 
      handWindow.ReturnCard(card);

    private void ProcessingCell(CardStaticData card, FieldCell cell)
    {
      if (IsCanSetCardToCell(card, cell))
        cell.SetUnlockView();
      else
        cell.SetLockedView();
    }

    private void SetCardToCell(CardStaticData card, FieldCell cell)
    {
      Card gameCard = cardSpawner.SpawnPlayerCard(card, cell.OffsetedYLocalPosition, field.FieldParent);
      cell.SetCard(gameCard);
    }

    private bool IsCanSetCardToCell(CardStaticData card, FieldCell cell) => 
      card.PlayingZoneType == cell.Type && cell.CurrentCard == null && cell.IsLocking == false;

    private bool HitCell() => 
      HitCount() > 0;

    private int HitCount()
    {
      Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
      return Physics.RaycastNonAlloc(ray, hits, raycastDistance, mask);
    }
  }
}