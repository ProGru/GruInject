using System;

namespace GruInject.Example.SettingsService.API
{
    public interface IVolumeSettings : IDisposable
    {
        int MasterVolume { get; set; }
        int VoiceVolume { get; set; }
    }
}