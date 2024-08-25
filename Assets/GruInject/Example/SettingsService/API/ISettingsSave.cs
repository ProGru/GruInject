using System;

namespace GruInject.Example.SettingsService.API
{
    public interface ISettingsSave : IDisposable
    {
        void Save();
    }
}