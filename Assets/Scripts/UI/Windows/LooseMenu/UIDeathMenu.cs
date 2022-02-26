using System;
using GameStates;
using GameStates.States;
using Services.Hero;
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
      
      private IGameStateMachine gameStateMachine;

      public void Construct(IGameStateMachine gameStateMachine, IPlayerTurns playerTurns)
      {
         this.gameStateMachine = gameStateMachine;
         descriptionText.text = String.Format(descriptionString, playerTurns.Count);
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

      private void LoadMenu()
      {
         gameStateMachine.Enter<MainMenuState>();
      }
   }
}
