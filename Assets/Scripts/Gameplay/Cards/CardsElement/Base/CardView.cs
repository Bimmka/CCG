using System;
using System.Collections;
using Coffee.UIExtensions;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Cards.CardsElement.Base
{
  public class CardView : MonoBehaviour
  {
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image mainImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image secondIconImage;
    [SerializeField] private UIDissolve backgroundDisolve;
    [SerializeField] private UIDissolve mainImageDisolve;
    [SerializeField] private UIDissolve iconImageDisolve;
    [SerializeField] private UIDissolve secondIconImageDisolve;

    public void SetView(CardStaticData data)
    {
      backgroundImage.sprite = data.Shirt;
      mainImage.sprite = data.Icon;
    }
    
    public void Show(Action callback = null)
    {
      Activate();
      StopAllCoroutines();
      StartCoroutine(Dissolve(backgroundDisolve, 0f, Time.deltaTime, -1, IsSmaller));
      StartCoroutine(Dissolve(mainImageDisolve, 0f, Time.deltaTime, -1, IsSmaller));
      StartCoroutine(Dissolve(iconImageDisolve, 0f, Time.deltaTime, -1, IsSmaller));
      StartCoroutine(Dissolve(secondIconImageDisolve, 0f, Time.deltaTime, -1, IsSmaller));
      StartCoroutine(Wait(1f,callback));
    }
    
    public void Hide(Action callback = null)
    {
      StopAllCoroutines();
      StartCoroutine(Dissolve(backgroundDisolve, 1f, Time.deltaTime, 1, IsBigger));
      StartCoroutine(Dissolve(mainImageDisolve, 1f, Time.deltaTime, 1, IsBigger));
      StartCoroutine(Dissolve(iconImageDisolve, 1f, Time.deltaTime, 1, IsBigger));
      StartCoroutine(Dissolve(secondIconImageDisolve, 1f, Time.deltaTime, 1, IsBigger));
      StartCoroutine(Wait(1f,callback,Deactivate));
    }

    private IEnumerator Dissolve(UIDissolve dissolver, float endValue, float step, int direction, Func<float, float, bool> isEnded)
    {
      float currentValue = dissolver.effectFactor;
      while (isEnded.Invoke(currentValue, endValue) == false)
      {
        currentValue += direction * step;
        dissolver.effectFactor = currentValue;
        yield return null;
      }
    }

    private IEnumerator Wait(float time, Action callback, Action localCallback = null)
    {
      yield return new WaitForSeconds(time);
      
      callback?.Invoke();
      localCallback?.Invoke();
    }

    private void Deactivate() => 
      gameObject.SetActive(false);

    private void Activate() => 
      gameObject.SetActive(true);

    private bool IsBigger(float current, float end) => 
      current >= end;

    private bool IsSmaller(float current, float end) => 
      current <= end;
  }
}