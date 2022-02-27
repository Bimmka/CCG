using DG.Tweening;
using Services.StaticData;
using UnityEngine;

namespace Services.Audio
{
  public class AudioService : IAudioService
  {
    private AudioSource mainSource;
    private readonly IAudioServiceSettings settings;
    private readonly IStaticDataService staticData;

    public AudioService(IAudioServiceSettings serviceSettings, IStaticDataService staticData)
    {
      settings = serviceSettings;
      this.staticData = staticData;
    }

    public void SaveMainThemeSource(AudioSource source)
    {
      mainSource = source;
    }

    public void ChangeMainTheme(string clipName)
    {
      mainSource.DOFade(0f, 1f).OnComplete(() => ChangeMainSound(clipName));
    }

    public void PlayerEffect(string clipName)
    {
      
    }

    public void StartPlayMenuTheme()
    {
      mainSource.clip = staticData.ForAudio("MenuTheme");
      mainSource.Play();
      mainSource.DOFade(1f, 1f);
    }

    private void ChangeMainSound(string clipName)
    {
      mainSource.clip = staticData.ForAudio(clipName);
      mainSource.DOFade(settings.MainVolume, 1f).OnComplete(() => ChangeMainSound(clipName));
      mainSource.Play();
    }
  }
}