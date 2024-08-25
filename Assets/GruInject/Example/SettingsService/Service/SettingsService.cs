using System;
using GruInject.API.Attributes;
using GruInject.Example.PersistenceOperations.API;
using GruInject.Example.SettingsService.API;

namespace GruInject.Example.SettingsService.Service
{
    [AutoSpawn]
    public class SettingsService : IVolumeSettings, ISettingsSave, IDisposable
    {
        [Inject] private IPersistenceLoader _persistenceLoader;
        [Inject] private IPersistenceSaver _persistenceSaver;
        private const string MASTER_VOLUME_KEY = "MASTER_VOLUME";
        private const string VOICE_VOLUME_KEY = "VOICE_VOLUME";
        
        public int MasterVolume { get; set; }
        public int VoiceVolume { get; set; }
        
        public SettingsService()
        {
            MasterVolume = _persistenceLoader.GetData(MASTER_VOLUME_KEY,0);
            VoiceVolume = _persistenceLoader.GetData(VOICE_VOLUME_KEY,0);
        }

        public void Save()
        {
            _persistenceSaver.SaveData(MASTER_VOLUME_KEY, MasterVolume);
            _persistenceSaver.SaveData(VOICE_VOLUME_KEY, VoiceVolume);
        }

        public void Dispose()
        {
        }
    }
}