using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace StaticData.Gameplay.Cards.Strategies
{
  [CreateAssetMenu(fileName = "CardStrategyStaticData", menuName = "Static Data / Cards /Strategy/Create Multiplier Property Strategy", order = 52)]
  public class MultiplierPropertyStrategyStaticData : CardStrategyStaticData
  {
    public int MultiplierCoeff = 2;
    
#if UNITY_EDITOR
    private void OnValidate()
    {
      Type = PlayingActionType.MultiplierProperty;
    }
#endif
  }
}