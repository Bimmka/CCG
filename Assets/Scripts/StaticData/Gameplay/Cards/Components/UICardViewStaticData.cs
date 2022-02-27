using UnityEngine;

namespace StaticData.Gameplay.Cards.Components
{
  [CreateAssetMenu(fileName = "UICardViewStaticData", menuName = "Static Data / Cards / Components / Create UI View Data", order = 52)]
  public class UICardViewStaticData : ScriptableObject
  {
    public float MaxAngle = 75;
    public float MinAngle = 25;
    public float YOffset = 0.5f;
    public float Duration = 0.2f;
  }
}