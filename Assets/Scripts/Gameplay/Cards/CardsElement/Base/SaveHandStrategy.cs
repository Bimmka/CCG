using Gameplay.Cards.Hand;
using StaticData.Gameplay.Cards.Strategies;

namespace Gameplay.Cards.CardsElement.Base
{
  public class SaveHandStrategy : CardUseStrategy
  {
    private readonly GameplayPlayerHand hand;

    public SaveHandStrategy(CardStrategyStaticData data, GameplayPlayerHand hand) : base(data)
    {
      this.hand = hand;
    }

    public override void Use()
    {
      hand.SaveHandForTurn();
      NotifyAboutEnd();
    }
  }
}