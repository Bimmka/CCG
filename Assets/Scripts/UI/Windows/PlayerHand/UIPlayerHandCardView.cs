using System;
using DG.Tweening;
using Gameplay.Cards.CardsElement.Base;
using Services.Random;
using StaticData.Gameplay.Cards.Components;
using StaticData.Gameplay.Cards.Elements;
using TMPro;
using UnityEngine;

namespace UI.Windows.PlayerHand
{
  public class UIPlayerHandCardView : BaseCardView
  {
    [SerializeField] private UICardViewStaticData uiViewData;
    
    private IRandomService randomService;

    public void Construct(IRandomService randomService) => 
      this.randomService = randomService;

    public override void Show(Action callback = null)
    {
      base.Show(callback);
      FadeText(1f);
    }

    public override void Hide(Action callback = null)
    {
      base.Hide(callback);
      StartCoroutine(Wait(data.TotalTime(), callback, OnHiden));
      FadeText(0f);
      Rotate();
      MoveDown();
    }

    public void ResetView()
    {
      
      StopAllCoroutines();
      mainImage.sprite = null;
      backgroundImage.sprite = null;
      nameText.text = "";
    }

    public void ForceHide()
    {
      gameObject.SetActive(false);
      ResetToDefault();
    }

    private void OnHiden()
    {
      gameObject.SetActive(false);
      ResetToDefault();
    }

    private void Rotate()
    {
      float angle = randomService.NextFloat(uiViewData.MinAngle, uiViewData.MaxAngle);
      transform.DOLocalRotate(Vector3.forward * angle, uiViewData.Duration).SetEase(Ease.InOutSine);
    }

    private void MoveDown()
    {
      transform.DOLocalMove(transform.localPosition - Vector3.up * uiViewData.YOffset, uiViewData.Duration)
        .SetEase(Ease.InOutSine);
    }

    private void FadeText(float alpha)
    {
      nameText.DOFade(alpha, data.FadeNameTextDuration).SetEase(Ease.InOutSine);
    }

    private void ResetToDefault()
    {
      backgroundDisolve.effectFactor = 1f;
      mainImageDisolve.effectFactor = 1f;
      DOTween.Kill(nameText);
      DOTween.Kill(transform);
      ChangeTextAlpha(nameText, 0f);
      transform.localRotation = Quaternion.identity;
      ResetView();
    }

    private void ChangeTextAlpha(TextMeshProUGUI text, float alpha)
    {
      Color color = text.color;
      color.a = alpha;
      text.color = color;
    }
  }
}