using UnityEngine;

namespace StaticData.UI.Animations
{
  [CreateAssetMenu(fileName = "DeathMenuAnimationData", menuName = "Static Data/UI/Animation/Create Death Menu Animation", order = 55)]
  public class DeathMenuAnimationData : ScriptableObject
  {
    public float ShadowMaxAlpha = 0.6f;
    public float ShadowDuration = 2f;
    public float ShadowDelay = 1f;
    public float BackgroundDuration = 2f;
    public float BackgroundDelay = 1f;
    public float HeadTextYOffset = 30f;
    public float HeadTextDuration = 1f;
    public float TextDelay = 1f;
    public float DescriptionTextYOffset = 40f;
    public float DescriptionTextDuration = 2f;
    public float ButtonDuration = 2f;
  }
}