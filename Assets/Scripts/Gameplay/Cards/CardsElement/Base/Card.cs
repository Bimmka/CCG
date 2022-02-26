using System;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class Card : MonoBehaviour
  {
    [SerializeField] private CardView view;

    private CardUseStrategy useStrategy;
    private CardStaticData data;

    


    public PlayingZoneType PlayingZoneType { get; private set; }
    public bool IsActivated { get; private set; }
    public bool IsCanceled { get; private set; }
    public CardStatus Status { get; private set; }
    public CardMover Mover { get; private set; }

    public event Action<Card> Hiden;
    public event Action<Card> Destroyed;

    public void Construct(CardStaticData staticData, CardUseStrategy newStrategy)
    {
      data = staticData;
      PlayingZoneType = data.PlayingZoneType;
      useStrategy = newStrategy;
      useStrategy.Ended += OnUseEnd;
    }

    public void Destroy()
    {
      UpdateStatus(CardStatus.Destroying);
      Hide();
      UpdateStatus(CardStatus.None);
      ResetData();
      Destroyed?.Invoke(this);
    }

    public void Show()
    {
      gameObject.SetActive(true);
    }

    public void Hide()
    {
      gameObject.SetActive(false);
      UpdateStatus(CardStatus.None);
    }

    public void Activate(Vector2Int cardPosition)
    {
      IsActivated = true;
      
      if (IsCanceled)
        return;
      
      UpdateStatus(CardStatus.Using);
      useStrategy.Use(cardPosition);
    }

    public void Block() => 
      IsCanceled = true;

    public void Unblock() => 
      IsCanceled = false;

    public void MultiplyOperationsNumber(int multiplier) => 
      ((IMultipliedCard)useStrategy).MultiplyOperationsCount(multiplier);

    public void Invert() => 
      ((IInvertableCard)useStrategy).Invert();


    public bool IsCanBeInverted() => 
      useStrategy is IInvertableCard;

    public bool IsCanBeMultiplied() => 
      useStrategy is IMultipliedCard;

    public bool IsCanBeBlocking() => 
      data.ImmuneType == CardImmuneType.Blocking;

    private void ResetUseStrategy()
    {
      useStrategy.Ended -= OnUseEnd;
      useStrategy = null;
    }

    private void OnUseEnd() => 
      UpdateStatus(CardStatus.None);


    private void UpdateStatus(CardStatus status) => 
      Status = status;

    private void ResetData()
    {
      IsActivated = false;
      IsCanceled = false;
      ResetUseStrategy();
    }
  }
}
