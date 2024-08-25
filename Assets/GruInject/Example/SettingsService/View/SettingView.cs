using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.Example.SettingsService.View
{
    public class SettingView : GruMonoBehaviour, ITabView
    {
        [Inject] private SettingsViewController _settingsViewController;
        [Inject] private SettingsTabManager _settingsTabManager;
        
        [SerializeField] private GameObject settingsView;
        [SerializeField] private UnityEngine.UI.Slider masterVolumeSlider;
        [SerializeField] private UnityEngine.UI.Slider voiceVolumeSlider;
        private bool areSettingsOpened = false;
        
        private void Start()
        {
            _settingsViewController.ConnectView(this);
        }

        public void OnSettingsClicked()
        {
            if (areSettingsOpened)
            {
                _settingsViewController.OnSettingsCloseClicked();
            }
            else
            {
                _settingsTabManager.ChangeOpenedTab(this);
                _settingsViewController.OnSettingsOpenClicked();
            }
            areSettingsOpened = !areSettingsOpened;
        }

        public void OnMasterValueChange()
        {
            _settingsViewController.OnMasterVolumeChanged((int)masterVolumeSlider.value);
        }
        
        public void OnVoiceValueChange()
        {
            _settingsViewController.OnVoiceVolumeChanged((int)voiceVolumeSlider.value);
        }

        public void ShowSettingsView()
        {
            settingsView.SetActive(true);
        }
        
        public void CloseSettingsView()
        {
            settingsView.SetActive(false);
        }

        public void SetMasterValue(int volumeSettingsMasterVolume)
        {
            masterVolumeSlider.SetValueWithoutNotify(volumeSettingsMasterVolume);
        }

        public void SetVoiceVolume(int volumeSettingsVoiceVolume)
        {
            voiceVolumeSlider.SetValueWithoutNotify(volumeSettingsVoiceVolume);
        }

        public void Close()
        {
            areSettingsOpened = false;
            CloseSettingsView();
        }
    }
}