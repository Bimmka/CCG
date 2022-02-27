using System;

namespace Services.Audio
{
  public class AudioServiceSettings : IAudioServiceSettings
  {
    public float MainVolume { get; private set; }
    public event Action Changed;

    public AudioServiceSettings()
    {
      MainVolume = 1f;
    }

    public void SetMainVolume(float value)
    {
      MainVolume = value;
    }
  }
}