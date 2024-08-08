using ExampleUsage.Settings.Interface;
using GruInject.API.Attributes;
using UnityEngine;

namespace ExampleUsage.SettingUsage
{
    public class UsageOfSetting  : GruMonoBehaviourEditMode
    {
        [Inject] private ISoundSettings _soundSettings;

        
        [ContextMenu("PrintSettings")]
        public void PrintSettings()
        {
            Debug.Log($"Sound Master {_soundSettings.MasterVolume}");
            Debug.Log($"Sound Theme {_soundSettings.VoiceTheme}");
        }
    }
}