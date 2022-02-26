using UnityEngine;

namespace StaticData.Gameplay.Cards.Strategies
{
  [CreateAssetMenu(fileName = "CardStrategyStaticData", menuName = "Static Data / Cards /Strategy/Create Gold Take Strategy", order = 52)]
  public class GoldTakeStrategyStaticData : CardStrategyStaticData
  {
    public int GoldTakeCount = 10;
  }
}