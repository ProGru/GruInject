using System;
using GruInject.API.Attributes;
using GruInject.Example.SettingsService.API;

namespace GruInject.Example.SettingsService.View
{
    [RegisterInstance]
    public class SettingsViewController : IDisposable
    {
        [Inject] private IVolumeSettings _volumeSettings;
        [Inject] private ISettingsSave _settingsSave;
        private SettingView _settingView;
        
        public void ConnectView(SettingView settingView)
        {
            _settingView = settingView;
        }

        public void OnSettingsOpenClicked()
        {
            _settingView.ShowSettingsView();
            _settingView.SetMasterValue(_volumeSettings.MasterVolume);
            _settingView.SetVoiceVolume(_volumeSettings.VoiceVolume);
        }

        public void OnSettingsCloseClicked()
        {
            _settingsSave.Save();
            _settingView.CloseSettingsView();
        }

        public void OnMasterVolumeChanged(int value)
        {
            _volumeSettings.MasterVolume = value;
        }

        public void OnVoiceVolumeChanged(int value)
        {
            _volumeSettings.VoiceVolume = value;
        }

        public void Dispose()
        {
        }
    }
}