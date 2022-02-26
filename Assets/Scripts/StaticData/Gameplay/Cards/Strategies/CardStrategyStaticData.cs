using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace StaticData.Gameplay.Cards.Strategies
{
  [CreateAssetMenu(fileName = "CardStrategyStaticData", menuName = "Static Data / Cards /Strategy/Create Strategy", order = 52)]
  public class CardStrategyStaticData : ScriptableObject
  {
    public PlayingActionType Type;
    public int MinOperationsNumber = 1;
  }
}