using ExampleUsage.Settings.Interface;
using GruInject.API.Attributes;

namespace ExampleUsage.Settings
{
    [AutoSpawn]
    public class SoundSettings : ISoundSettings
    {
        private int _masterVolume = 1;
        private int _effectVolume = 1;
        private int _voiceVolume = 1;
        private VoiceTheme _voiceTheme = VoiceTheme.Man;

        public int MasterVolume => _masterVolume;
        public int EffectsVolume => _effectVolume;
        public int VoiceVolume => _voiceVolume;
        public VoiceTheme VoiceTheme => _voiceTheme;

        public void Dispose()
        {
        }
    }
}