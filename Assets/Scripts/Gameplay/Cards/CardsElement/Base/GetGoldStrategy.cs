using System.Collections;
using Services;
using Services.Hero;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class GetGoldStrategy : CardUseStrategy, IInvertableCard
  {
    private readonly IPlayerGold playerGold;
    private readonly int GoldCount;

    private bool isGet = true;

    public GetGoldStrategy(CardStrategyStaticData data, ICoroutineRunner coroutineRunner,  IPlayerGold playerGold) : base(data, coroutineRunner)
    {
      this.playerGold = playerGold;
      GoldCount = ((GoldTakeStrategyStaticData) data).GoldTakeCount;
    }
    
    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Steal());
    }
    
    private IEnumerator Steal()
    {
      yield return new WaitForSeconds(1f);
      if (isGet)
        playerGold.Add(GoldCount);
      else
        playerGold.Steal(GoldCount);
      
      NotifyAboutEnd();
      yield return new WaitForSeconds(1f);
      NotifyAboutEnd();
    }

    public void Invert()
    {
      isGet = false;
    }
  }
}