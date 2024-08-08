using System;

namespace ExampleUsage.Settings.Interface
{
    public interface ISoundSettings : IDisposable
    {
        public int MasterVolume { get; }
        public int EffectsVolume { get; }
        public int VoiceVolume { get; }
        public VoiceTheme VoiceTheme { get; }
    }
}