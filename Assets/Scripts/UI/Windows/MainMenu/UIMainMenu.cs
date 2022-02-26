using ConstantsValue;
using GameStates;
using GameStates.States;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class UIMainMenu : BaseWindow
    {
        [SerializeField] private Button playButton;
        
        private IGameStateMachine stateMachine;

        public void Construct(IGameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        protected override void Subscribe()
        {
            base.Subscribe();
            playButton.onClick.AddListener(Play);
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            playButton.onClick.RemoveListener(Play);
        }

        private void Play()
        {
            stateMachine.Enter<LoadGameLevelState, string>(Constants.GameScene);
        }
    }
}
