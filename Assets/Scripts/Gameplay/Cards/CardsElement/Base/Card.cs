using System;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class Card : MonoBehaviour
  {
    [SerializeField] private CardView view;

    private CardMover mover;
    private CardUseStrategy useStrategy;

    private CardStaticData data;
    
    public PlayingZoneType PlayingZoneType { get; private set; }

    public event Action<Card> Hiden;

    public void Construct(CardStaticData staticData)
    {
      data = staticData;
      PlayingZoneType = data.PlayingZoneType;
    }

    public void Show()
    {
      gameObject.SetActive(true);
    }

    public void Hide()
    {
      gameObject.SetActive(false);
    }
  }
}
