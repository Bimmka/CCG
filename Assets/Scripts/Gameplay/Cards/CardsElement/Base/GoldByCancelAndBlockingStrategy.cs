using System.Collections;
using Services;
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

    public GoldByCancelAndBlockingStrategy(CardStrategyStaticData data, ICoroutineRunner coroutineRunner, IPlayerGold playerGold) : base(data, coroutineRunner)
    {
      this.playerGold = playerGold;
      goldCount = ((GoldByCancelStrategyStaticData) data).GoldTakeCount;
      additinalGoldCount = ((GoldByCancelStrategyStaticData) data).AdditionalMoney;
    }
    
    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Using());
    }

    private IEnumerator Using()
    {
      yield return new WaitForSeconds(1f);
      if (isSteal)
        playerGold.Steal(goldCount + additinalGoldCount);
      else
        playerGold.Add(goldCount + additinalGoldCount);
      yield return new WaitForSeconds(1f);
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