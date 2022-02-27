using System;
using System.Collections;
using Coffee.UIExtensions;
using DG.Tweening;
using GameStates;
using GameStates.States;
using Services.Hero;
using StaticData.UI.Animations;
using TMPro;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.LooseMenu
{
   public class UIDeathMenu : BaseWindow
   {
      [SerializeField] private TextMeshProUGUI descriptionText;
      [SerializeField] private Button menuButton;
      [TextArea]
      [SerializeField] private string descriptionString;

      [Header("Animation")] 
      [SerializeField] private Image shadow;
      [SerializeField] private UIDissolve backgroundDissolve;
      [SerializeField] private TextMeshProUGUI headText;
      [SerializeField] private Image menuButtonImage;
      [SerializeField] private TextMeshProUGUI menuButtonText;
      [SerializeField] private DeathMenuAnimationData data;
      
      private IGameStateMachine gameStateMachine;

      public void Construct(IGameStateMachine gameStateMachine, IPlayerTurns playerTurns)
      {
         this.gameStateMachine = gameStateMachine;
         descriptionText.text = String.Format(descriptionString, playerTurns.Count);
      }

      public override void Open()
      {
         base.Open();
         StartCoroutine(ApplyShadow());
      }

      protected override void Subscribe()
      {
         base.Subscribe();
         menuButton.onClick.AddListener(LoadMenu);
      }

      protected override void Cleanup()
      {
         base.Cleanup();
         menuButton.onClick.RemoveListener(LoadMenu);
      }

      private IEnumerator ApplyShadow()
      {
         shadow.DOFade(data.ShadowMaxAlpha, data.ShadowDuration).SetEase(Ease.InOutSine);
         yield return new WaitForSeconds(data.ShadowDelay);
         StartCoroutine(ApplyBackground());
      }

      private IEnumerator ApplyBackground()
      {
         StartCoroutine(WaitBackgroundDelay());
         float step = backgroundDissolve.effectFactor / data.BackgroundDuration; 
         while (backgroundDissolve.effectFactor <= 0 == false)
         {
            backgroundDissolve.effectFactor -=  step * Time.deltaTime;
            yield return null;
         }
      }

      private IEnumerator WaitBackgroundDelay()
      {
         yield return new WaitForSeconds(data.BackgroundDelay);
         StartCoroutine(ApplyText());
      }

      private IEnumerator ApplyText()
      {
         headText.transform.localPosition += Vector3.up * data.HeadTextYOffset;
         descriptionText.transform.localPosition -= Vector3.up * data.DescriptionTextYOffset;
         headText.transform.DOLocalMove(headText.transform.localPosition - Vector3.up * data.HeadTextYOffset, data.HeadTextDuration)
            .SetEase(Ease.InOutSine);
         headText.DOFade(1f, data.HeadTextDuration).SetEase(Ease.InOutSine);
         
         yield return new WaitForSeconds(data.TextDelay);
         
         descriptionText.transform.DOLocalMove(descriptionText.transform.localPosition + Vector3.up * data.DescriptionTextYOffset, data.DescriptionTextDuration)
            .SetEase(Ease.InOutSine);
         descriptionText.DOFade(1f, data.DescriptionTextDuration).SetEase(Ease.InOutSine);
         
         yield return new WaitForSeconds(data.TextDelay);

         menuButtonImage.DOFade(1f, data.ButtonDuration).SetEase(Ease.InOutSine).OnComplete(ActivateButton);
         menuButtonText.DOFade(1f, data.ButtonDuration).SetEase(Ease.InOutSine);
      }

      private void ActivateButton() => 
         menuButton.enabled = true;

      private void LoadMenu()
      {
         gameStateMachine.Enter<MainMenuState>();
      }
   }
}
