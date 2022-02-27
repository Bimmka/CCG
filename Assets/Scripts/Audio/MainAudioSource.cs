using System;
using System.Collections.Generic;
using DG.Tweening;
using Services.Audio;
using UnityEngine;

namespace Audio
{
  public class MainAudioSource : MonoBehaviour
  {
    [SerializeField] private AudioSource source;
    [SerializeField] private EffectAudioSource prefab;
    
    private IAudioService audioService;
    
    private readonly Queue<EffectAudioSource> pool = new Queue<EffectAudioSource>(3); 

    public void Construct(IAudioService audioService)
    {
      this.audioService = audioService;
      this.audioService.SaveMainThemeSource(this);
    }

    private void OnDestroy()
    {
      EffectAudioSource effectSource;
      while (pool.Count > 0)
      {
        effectSource = pool.Dequeue();
        effectSource.Ended -= OnSourceEnd;
      }
    }

    public void SetClip(AudioClip forAudio)
    {
      source.clip = forAudio;
    }

    public void Play()
    {
      source.Play();
    }

    public void Stop()
    {
      source.Stop();
    }

    public void ChangeVolume(float endValue, int changeDuration, Action callback = null)
    {
      source.DOFade(endValue, changeDuration).OnComplete(() => callback?.Invoke());
    }

    public void PlayEffect(AudioClip forAudio)
    {
      if (pool.Count > 0)
        ReuseSource(pool.Dequeue(),forAudio);
      else
        UseNewSource(forAudio);
    }

    private void UseNewSource(AudioClip forAudio)
    {
      EffectAudioSource effectAudioSource = Instantiate(prefab, transform);
      effectAudioSource.Ended += OnSourceEnd;
      effectAudioSource.Play(forAudio);
    }

    private void OnSourceEnd(EffectAudioSource effectSource)
    {
      pool.Enqueue(effectSource);
      effectSource.Stop();
      effectSource.gameObject.SetActive(false);
    }

    private void ReuseSource(EffectAudioSource effectAudioSource, AudioClip forAudio)
    {
      effectAudioSource.gameObject.SetActive(true);
      effectAudioSource.Play(forAudio);
    }
    
    
  }
}