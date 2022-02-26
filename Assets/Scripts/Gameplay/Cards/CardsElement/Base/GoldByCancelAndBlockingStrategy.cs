using Services.Hero;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class GoldByCancelAndBlockingStrategy : CardUseStrategy, ITriggered
  {
    private readonly IPlayerGold playerGold;

    private readonly int goldCount;
    private readonly int additinalGoldCount;
    private bool isSteal = true;

    public GoldByCancelAndBlockingStrategy(CardStrategyStaticData data, IPlayerGold playerGold) : base(data)
    {
      this.playerGold = playerGold;
      goldCount = ((GoldByCancelStrategyStaticData) data).GoldTakeCount;
      additinalGoldCount = ((GoldByCancelStrategyStaticData) data).AdditionalMoney;
    }

    public override void Use(Vector2Int startPosition)
    {
      if (isSteal)
        playerGold.Steal(goldCount + additinalGoldCount);
      else
        playerGold.Add(goldCount + additinalGoldCount);
      
      NotifyAboutEnd();
    }

    public bool IsCanBeTriggered(CardUseStrategy strategy)
    {
      return strategy.GetType() == typeof(BlockNearestActionsStrategy) || strategy.GetType() == typeof(CancelOpponentPropertyStrategy);
    }

    public void Trigger() => 
      isSteal = false;
  }
}