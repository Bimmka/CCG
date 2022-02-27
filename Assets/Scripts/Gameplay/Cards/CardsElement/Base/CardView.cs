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
    [SerializeField] private Image iconImage;
    [SerializeField] private Image secondIconImage;
   
    [SerializeField] private UIDissolve iconImageDisolve;
    [SerializeField] private UIDissolve secondIconImageDisolve;
    
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
      StartCoroutine(Dissolve(iconImageDisolve, 0f, data.DissolveFirstIconDuration, -1, IsSmaller));
      StartCoroutine(Dissolve(secondIconImageDisolve, 0f,  data.DissolveSecondIconDuration, -1, IsSmaller));
      StartCoroutine(DissolveObject(1f, 0f, data.ObjectDissolveDuration, -1, IsSmaller));
      StartCoroutine(Wait(data.TotalTime(),callback));
    }
    public override void Hide(Action callback = null)
    {
      base.Hide(callback);
      StartCoroutine(Dissolve(iconImageDisolve, 1f,  data.DissolveFirstIconDuration, 1, IsBigger));
      StartCoroutine(Dissolve(secondIconImageDisolve, 1f,  data.DissolveSecondIconDuration, 1, IsBigger));
      StartCoroutine(DissolveObject(0f, 1f, data.ObjectDissolveDuration, 1, IsBigger));
      StartCoroutine(Wait(data.TotalTime(),callback,Deactivate));
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