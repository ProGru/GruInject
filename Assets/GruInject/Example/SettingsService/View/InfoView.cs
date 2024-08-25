using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.Example.SettingsService.View
{
    public class InfoView : GruMonoBehaviour, ITabView
    {
        [SerializeField] private GameObject infoView;
        [Inject] private SettingsTabManager _settingsTabManager;
        private bool areSettingsOpened = false;
        
        public void OnSettingsClicked()
        {
            if (areSettingsOpened)
            {
                infoView.SetActive(false);
            }
            else
            {
                _settingsTabManager.ChangeOpenedTab(this);
                infoView.SetActive(true);
            }
            areSettingsOpened = !areSettingsOpened;
        }

        public void Close()
        {
            areSettingsOpened = false;
            infoView.SetActive(false);
        }
    }
}