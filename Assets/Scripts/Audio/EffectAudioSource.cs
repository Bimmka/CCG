using System;
using System.Collections;
using UnityEngine;

namespace Audio
{
  public class EffectAudioSource : MonoBehaviour
  {
    [SerializeField] private AudioSource source;

    public event Action<EffectAudioSource> Ended;

    public void Play(AudioClip clip)
    {
      source.clip = clip;
      source.Play();
      StartCoroutine(WaitPlay());
    }

    public void Stop()
    {
      source.Stop();
    }

    private IEnumerator WaitPlay()
    {
      while (source.isPlaying)
      {
        yield return null;
      }
      
      Ended?.Invoke(this);
    }
  }
}