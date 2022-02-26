using UnityEngine;

namespace StaticData.Gameplay.Cards.Strategies
{
  [CreateAssetMenu(fileName = "CardStrategyStaticData", menuName = "Static Data / Cards /Strategy/Create Gold By Cancel Strategy", order = 52)]
  public class GoldByCancelStrategyStaticData : GoldTakeStrategyStaticData
  {
    public int AdditionalMoney = 1;
  }
}