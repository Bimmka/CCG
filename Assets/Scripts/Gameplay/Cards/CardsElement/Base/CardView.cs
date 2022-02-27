using System;
using System.Collections;
using Coffee.UIExtensions;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Cards.CardsElement.Base
{
  public class CardView : BaseCardView
  {
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private ParticleSystem particles;
    
    private MaterialPropertyBlock propBlock;

    private readonly string AlphaThreshold = "_AlphaThreshold";
    private readonly string EmissionThreshold = "_EmissionThreshold";

    private void Awake()
    {
      propBlock = new MaterialPropertyBlock();
    }

    public override void Show(Action callback = null)
    {
      base.Show(callback);
      StartCoroutine(DissolveObject(1f, 0f, data.ObjectDissolveDuration, -1, IsSmaller));
      StartCoroutine(Wait(data.TotalTime(),callback));
    }
    public override void Hide(Action callback = null)
    {
      base.Hide(callback);
      StartCoroutine(DissolveObject(0f, 1f, data.ObjectDissolveDuration, 1, IsBigger));
      StartCoroutine(Wait(data.TotalTime(),callback,Deactivate));
    }

    public void ShowParticles()
    {
      particles.transform.gameObject.SetActive(true);
      particles.Play();
    }

    public void RemoveParticles()
    {
      particles.Stop();
      particles.transform.gameObject.SetActive(false);
    }

    private IEnumerator DissolveObject(float startValue, float endValue, float duration, int direction, Func<float, float, bool> isEnded)
    {
      float currentValue = startValue;
      
      float step = Mathf.Abs(endValue - currentValue) / duration; 
      while (isEnded.Invoke(currentValue, endValue) == false)
      {
        objectRenderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat(AlphaThreshold, currentValue);
        propBlock.SetFloat(EmissionThreshold, currentValue + direction * -1);
        objectRenderer.SetPropertyBlock(propBlock);
        currentValue += direction * step * Time.deltaTime;
        yield return null;
      }
    }
  }
}