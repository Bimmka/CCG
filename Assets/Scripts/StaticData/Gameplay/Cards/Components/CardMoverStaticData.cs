using UnityEngine;

namespace StaticData.Gameplay.Cards.Components
{
  [CreateAssetMenu(fileName = "CardMoverStaticData", menuName = "Static Data / Cards / Components / Create Mover Data", order = 52)]
  public class CardMoverStaticData : ScriptableObject
  {
    public float UpDuration = 1f;
    public float MoveDuration = 1f;
    public float DownDuration =1f;
    public float YOffset = 1f;
    public float XPercentEndpointsOffset = 1f;

    public float TotalDuration => UpDuration + MoveDuration + DownDuration;
  }
}