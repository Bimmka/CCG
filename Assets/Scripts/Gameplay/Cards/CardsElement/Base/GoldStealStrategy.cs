using System.Collections;
using Services;
using Services.Hero;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class GoldStealStrategy : CardUseStrategy, IInvertableCard, IMultipliedCard
  {
    private readonly IPlayerGold playerGold;
    private readonly int GoldCount;

    private bool isSteal = true;

    public GoldStealStrategy(CardStrategyStaticData data, ICoroutineRunner coroutineRunner, IPlayerGold playerGold) : base(data, coroutineRunner)
    {
      this.playerGold = playerGold;
      GoldCount = ((GoldStealStrategyStaticData) data).GoldStealCount;
    }
    
    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Steal());
    }

    private IEnumerator Steal()
    {
      for (int i = 0; i < OperationsCount; i++)
      {
        if (isSteal)
          playerGold.Steal(GoldCount);
        else
          playerGold.Add(GoldCount);
        yield return new WaitForSeconds(1f);
      }
      yield return new WaitForSeconds(1f);
      NotifyAboutEnd();
    }

    public void Invert()
    {
      isSteal = false;
    }

    public void MultiplyOperationsCount(int multiplier) => 
      MultiplyOperations(multiplier);
  }
}