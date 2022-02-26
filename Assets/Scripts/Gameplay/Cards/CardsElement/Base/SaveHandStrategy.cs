using Gameplay.Cards.Hand;
using Services.Cards.Hand;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class SaveHandStrategy : CardUseStrategy
  {
    private readonly IPlayerHand hand;

    public SaveHandStrategy(CardStrategyStaticData data, IPlayerHand hand) : base(data)
    {
      this.hand = hand;
    }

    public override void Use(Vector2Int cardPosition)
    {
      hand.SetSaveCard();
      NotifyAboutEnd();
    }
  }
}