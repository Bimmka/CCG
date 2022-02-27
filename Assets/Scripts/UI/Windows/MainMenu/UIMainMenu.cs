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
        [SerializeField] private Button faqButton;
        [SerializeField] private Button closeFaqButton;
        [SerializeField] private GameObject faqHolder;
        
        private IGameStateMachine stateMachine;

        public void Construct(IGameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        protected override void Subscribe()
        {
            base.Subscribe();
            playButton.onClick.AddListener(Play);
            faqButton.onClick.AddListener(OpenFaq);
            closeFaqButton.onClick.AddListener(CloseFaq);
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            playButton.onClick.RemoveListener(Play);
            faqButton.onClick.RemoveListener(OpenFaq);
            closeFaqButton.onClick.RemoveListener(CloseFaq);
        }

        private void OpenFaq() => 
            faqHolder.SetActive(true);

        private void CloseFaq() => 
            faqHolder.SetActive(false);

        private void Play()
        {
            stateMachine.Enter<LoadGameLevelState, string>(Constants.GameScene);
        }
    }
}
