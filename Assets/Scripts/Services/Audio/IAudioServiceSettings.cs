using System;

namespace Services.Audio
{
  public interface IAudioServiceSettings : IService
  {
    float MainVolume { get; }
    float EffectsVolume { get; }
    float BackgroundVolume { get; }

    void SetMainVolume(float value);
    void SetEffectsVolume(float value);
    void SetBackgroundVolume(float value);

    void Save();
    void Load();
  }
}