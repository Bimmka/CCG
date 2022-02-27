using Audio;
using DG.Tweening;
using Services.StaticData;
using UnityEngine;

namespace Services.Audio
{
  public class AudioService : IAudioService
  {
    private MainAudioSource mainSource;
    private readonly IAudioServiceSettings settings;
    private readonly IStaticDataService staticData;

    private readonly int ChangeDuration = 1;

    public AudioService(IAudioServiceSettings serviceSettings, IStaticDataService staticData)
    {
      settings = serviceSettings;
      this.staticData = staticData;
    }

    public void SaveMainThemeSource(MainAudioSource source)
    {
      mainSource = source;
    }

    public void ChangeMainTheme(string clipName)
    {
      mainSource.ChangeVolume(0f, ChangeDuration,() => ChangeMainSound(clipName));
    }

    public void PlayerEffect(string clipName)
    {
      mainSource.PlayEffect(staticData.ForAudio(clipName));
    }

    public void StartPlayMenuTheme()
    {
      mainSource.SetClip(staticData.ForAudio("MenuTheme"));
      mainSource.Play();
      mainSource.ChangeVolume(1f, ChangeDuration);
    }

    private void ChangeMainSound(string clipName)
    {
      mainSource.SetClip(staticData.ForAudio(clipName));
      mainSource.ChangeVolume(settings.MainVolume, ChangeDuration);
      mainSource.Play();
    }
  }
}