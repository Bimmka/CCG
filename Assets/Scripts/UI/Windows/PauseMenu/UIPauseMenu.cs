using System;
using GameStates;
using GameStates.States;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.PauseMenu
{
    public class UIPauseMenu : BaseWindow
    {
        [SerializeField] private Button exitLevelButton;
        
        private IGameStateMachine gameStateMachine;

        public void Construct(IGameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }

        public override void Close()
        {
            base.Close();
            Destroy(gameObject);
        }

        protected override void Subscribe()
        {
            base.Subscribe();
            exitLevelButton.onClick.AddListener(LoadMenu);
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            exitLevelButton.onClick.RemoveListener(LoadMenu);
        }

        private void LoadMenu()
        {
            gameStateMachine.Enter<MainMenuState>();
        }
    }
}
