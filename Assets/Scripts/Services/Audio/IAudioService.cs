using Audio;

namespace Services.Audio
{
  public interface IAudioService : IService
  {
    void SaveMainThemeSource(MainAudioSource source);
    void ChangeMainTheme(string clipName);
    void PlayerEffect(string clipName);
    void StartPlayMenuTheme();
  }
}