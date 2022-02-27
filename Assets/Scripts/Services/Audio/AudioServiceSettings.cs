using ConstantsValue;
using UnityEngine;
using UnityEngine.Audio;

namespace Services.Audio
{
  public class AudioServiceSettings : IAudioServiceSettings
  {
    private readonly AudioMixer mixer;
    public float MainVolume { get; private set; }
    public float EffectsVolume { get; private set; }
    public float BackgroundVolume { get; private set; }

    public AudioServiceSettings(AudioMixer mixer)
    {
      this.mixer = mixer;
    }

    public void SetMainVolume(float value)
    {
      MainVolume = value;
      ChangeGroupValue(Constants.Master, value);
    }

    public void SetEffectsVolume(float value)
    {
      EffectsVolume = value;
      ChangeGroupValue(Constants.Effect, value);
    }

    public void SetBackgroundVolume(float value)
    {
      BackgroundVolume = value;
      ChangeGroupValue(Constants.Background, value);
    }

    public void Load()
    {
      SetMainVolume(PlayerPrefs.GetFloat(Constants.Master,1f));
      SetEffectsVolume(PlayerPrefs.GetFloat(Constants.Effect, 1f));
      SetBackgroundVolume(PlayerPrefs.GetFloat(Constants.Background, 1f));
    }

    public void Save()
    {
      PlayerPrefs.SetFloat(Constants.Master, MainVolume);
      PlayerPrefs.SetFloat(Constants.Effect, EffectsVolume);
      PlayerPrefs.SetFloat(Constants.Background, BackgroundVolume);
    }

    private void ChangeGroupValue(string name, float value) => 
      mixer.SetFloat(name, Mathf.Log10(value) * Constants.AudioMixerMultiplier);
  }
}