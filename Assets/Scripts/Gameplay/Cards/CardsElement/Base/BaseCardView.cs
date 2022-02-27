using System;
using System.Collections;
using Coffee.UIExtensions;
using StaticData.Gameplay.Cards.Components;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Cards.CardsElement.Base
{
  public class BaseCardView : MonoBehaviour
  {
    [SerializeField] protected Image backgroundImage;
    [SerializeField] protected Image mainImage;
    [SerializeField] protected UIDissolve backgroundDisolve;
    [SerializeField] protected UIDissolve mainImageDisolve;
    [SerializeField] protected CardViewStaticData data;
    
    public virtual void SetView(CardStaticData data)
    {
      backgroundImage.sprite = data.Shirt;
      mainImage.sprite = data.Icon;
    }

    public virtual void Show(Action callback = null)
    {
      Activate();
      StopAllCoroutines();
      StartCoroutine(Dissolve(backgroundDisolve, 0f, data.DissolveBackgroundDuration, -1, IsSmaller));
      StartCoroutine(Dissolve(mainImageDisolve, 0f, data.DissolveMainImageDuration, -1, IsSmaller));
    }

    public virtual void Hide(Action callback = null)
    {
      StopAllCoroutines();
      StartCoroutine(Dissolve(backgroundDisolve, 1f, data.DissolveBackgroundDuration, 1, IsBigger));
      StartCoroutine(Dissolve(mainImageDisolve, 1f, data.DissolveMainImageDuration, 1, IsBigger));
    }
    
    protected virtual void Deactivate() => 
      gameObject.SetActive(false);

    protected virtual void Activate() => 
      gameObject.SetActive(true);
    
    protected IEnumerator Dissolve(UIDissolve dissolver, float endValue, float duration, int direction, Func<float, float, bool> isEnded)
    {
      float currentValue = dissolver.effectFactor;
      float step = Mathf.Abs(endValue - currentValue) / duration; 
      while (isEnded.Invoke(currentValue, endValue) == false)
      {
        currentValue += direction * step * Time.deltaTime;
        dissolver.effectFactor = currentValue;
        yield return null;
      }
    }

    protected IEnumerator Wait(float time, Action callback, Action localCallback = null)
    {
      yield return new WaitForSeconds(time);
      
      callback?.Invoke();
      localCallback?.Invoke();
    }
    protected bool IsBigger(float current, float end) => 
      current >= end;

    protected bool IsSmaller(float current, float end) => 
      current <= end;
  }
}