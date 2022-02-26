using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace StaticData.Gameplay.Cards.Strategies
{
  [CreateAssetMenu(fileName = "CardStrategyStaticData", menuName = "Static Data / Cards /Strategy/Create Gold Steal Strategy", order = 52)]
  public class GoldStealStrategyStaticData : CardStrategyStaticData
  {
    public int GoldStealCount = 10;
    
#if UNITY_EDITOR
    private void OnValidate()
    {
      Type = PlayingActionType.GoldSteal;
    }
#endif
  }
}