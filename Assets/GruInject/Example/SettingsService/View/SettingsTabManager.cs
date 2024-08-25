using System;
using GruInject.API.Attributes;

namespace GruInject.Example.SettingsService.View
{
    [AutoSpawn]
    public class SettingsTabManager : IDisposable
    {
        private ITabView _lastOpenedTabView;

        public void ChangeOpenedTab(ITabView tabView)
        {
            if (_lastOpenedTabView != null)
            {
                if (_lastOpenedTabView != tabView)
                {
                    _lastOpenedTabView.Close();
                    _lastOpenedTabView = tabView;
                }
            }
            else
            {
                _lastOpenedTabView = tabView;
            }
        }

        public void Dispose()
        {
        }
    }
}