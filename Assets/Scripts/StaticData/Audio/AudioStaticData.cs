using System.Collections.Generic;
using UnityEngine;

namespace StaticData.Audio
{
  [CreateAssetMenu(fileName = "AudioStaticData", menuName = "Static Data / Audio / Create Audio Bank", order = 52)]
  public class AudioStaticData : ScriptableObject
  {
    public List<BankAudioClip> Clips;
  }
}