using UnityEngine;

namespace StaticData.Gameplay.Cards.Components
{
  [CreateAssetMenu(fileName = "CardViewStaticData", menuName = "Static Data / Cards / Components / Create View Data", order = 52)]
  public class CardViewStaticData : ScriptableObject
  {
    public float DissolveBackgroundDuration= 0.2f;
    public float DissolveMainImageDuration = 0.2f;
    public float DissolveFirstIconDuration = 0.2f;
    public float DissolveSecondIconDuration = 0.2f;
    public float FadeNameTextDuration = 0.2f;
    public float FadeDescriptionDuration = 0.2f;
    public float MaxTextAlpha = 1f;
    public float MinTextAlpha = 0f;

    public float TotalTime()
    {
      float max = DissolveBackgroundDuration;
      
      if (max < DissolveMainImageDuration)
        max = DissolveMainImageDuration;

      if (max < DissolveFirstIconDuration)
        max = DissolveFirstIconDuration;
      
      if (max < DissolveSecondIconDuration)
        max = DissolveSecondIconDuration;
      
      if (max < FadeNameTextDuration)
        max = FadeNameTextDuration;
      
      if (max < FadeDescriptionDuration)
        max = FadeDescriptionDuration;

      return max;
    }
  }
}