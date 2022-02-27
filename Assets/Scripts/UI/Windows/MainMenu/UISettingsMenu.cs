using ConstantsValue;
using Services.Audio;
using UI.Base;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI.Windows.MainMenu
{
    public class UISettingsMenu : BaseWindow
    {
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider effectSlider;
        [SerializeField] private Slider backgroundSlider;
        [SerializeField] private Button closeButton;
        
        private IAudioServiceSettings audioSettings;

        public void Construct(IAudioServiceSettings audioSettings)
        {
            this.audioSettings = audioSettings;
            Load();
            SetDefaultValues();
        }

        protected override void Subscribe()
        {
            base.Subscribe();
            masterSlider.onValueChanged.AddListener(ChangeMasterValue);
            effectSlider.onValueChanged.AddListener(ChangeEffectValue);
            backgroundSlider.onValueChanged.AddListener(ChangeBackgroundValue);
            closeButton.onClick.AddListener(Close);
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            masterSlider.onValueChanged.RemoveListener(ChangeMasterValue);
            effectSlider.onValueChanged.RemoveListener(ChangeEffectValue);
            backgroundSlider.onValueChanged.RemoveListener(ChangeBackgroundValue);
            closeButton.onClick.RemoveListener(Close);
        }
        
        public override void Close()
        {
            base.Close();
            Save();
            Destroy(gameObject);
        }

        private void Save() => 
            audioSettings.Save();

        private void Load()
        {
            masterSlider.value = audioSettings.MainVolume;
            effectSlider.value = audioSettings.EffectsVolume;
            backgroundSlider.value = audioSettings.BackgroundVolume;
        }

        private void ChangeBackgroundValue(float value) => 
            audioSettings.SetBackgroundVolume(value);

        private void ChangeEffectValue(float value) => 
            audioSettings.SetEffectsVolume(value);

        private void ChangeMasterValue(float value) => 
            audioSettings.SetMainVolume(value);


        private void SetDefaultValues()
        {
            ChangeMasterValue(masterSlider.value);
            ChangeBackgroundValue(backgroundSlider.value);
            ChangeEffectValue(effectSlider.value);
        }
    }
}
