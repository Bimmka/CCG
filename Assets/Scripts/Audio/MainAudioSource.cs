using Services.Audio;
using UnityEngine;

namespace Audio
{
  public class MainAudioSource : MonoBehaviour
  {
    [SerializeField] private AudioSource source;
    
    private IAudioService audioService;

    public void Construct(IAudioService audioService)
    {
      this.audioService = audioService;
      this.audioService.SaveMainThemeSource(source);
      this.audioService.StartPlayMenuTheme();
    }
  }
}