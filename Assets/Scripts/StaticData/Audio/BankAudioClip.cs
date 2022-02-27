using System;
using UnityEngine;

namespace StaticData.Audio
{
  [Serializable]
  public struct BankAudioClip
  {
    public string Name;
    public AudioClip Clip;
  }
}