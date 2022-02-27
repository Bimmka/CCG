using UnityEngine;

namespace Services.Audio
{
  public interface IAudioService : IService
  {
    void SaveMainThemeSource(AudioSource source);
    void ChangeMainTheme(string clipName);
    void PlayerEffect(string clipName);
    void StartPlayMenuTheme();
  }
}