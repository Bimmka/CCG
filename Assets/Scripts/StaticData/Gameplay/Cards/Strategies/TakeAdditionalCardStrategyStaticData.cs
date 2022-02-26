using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace StaticData.Gameplay.Cards.Strategies
{
  [CreateAssetMenu(fileName = "CardStrategyStaticData", menuName = "Static Data / Cards /Strategy/Create Additional Card Strategy", order = 52)]
  public class TakeAdditionalCardStrategyStaticData : CardStrategyStaticData
  {
    public int AdditionalCardCount = 1;
    
#if UNITY_EDITOR
    private void OnValidate()
    {
      Type = PlayingActionType.TakeAdditionalCard;
    }
#endif
  }
}