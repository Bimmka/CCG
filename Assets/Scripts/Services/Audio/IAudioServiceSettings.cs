using System;

namespace Services.Audio
{
  public interface IAudioServiceSettings : IService
  {
    float MainVolume { get; }
    event Action Changed;

    void SetMainVolume(float value);

  }
}