using System;
using Coffee.UIExtensions;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Cards.CardsElement.Base
{
  public class CardView : BaseCardView
  {
   
    [SerializeField] private Image iconImage;
    [SerializeField] private Image secondIconImage;
   
    [SerializeField] private UIDissolve iconImageDisolve;
    [SerializeField] private UIDissolve secondIconImageDisolve;
    
    public override void Show(Action callback = null)
    {
      base.Show(callback);
      StartCoroutine(Dissolve(iconImageDisolve, 0f, data.DissolveFirstIconDuration, -1, IsSmaller));
      StartCoroutine(Dissolve(secondIconImageDisolve, 0f,  data.DissolveSecondIconDuration, -1, IsSmaller));
      StartCoroutine(Wait(1f,callback));
    }
    public override void Hide(Action callback = null)
    {
      base.Hide(callback);
      StartCoroutine(Dissolve(iconImageDisolve, 1f,  data.DissolveFirstIconDuration, 1, IsBigger));
      StartCoroutine(Dissolve(secondIconImageDisolve, 1f,  data.DissolveSecondIconDuration, 1, IsBigger));
      StartCoroutine(Wait(1f,callback,Deactivate));
    }
  }
}