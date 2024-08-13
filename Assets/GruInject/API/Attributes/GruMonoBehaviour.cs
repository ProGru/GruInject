using UnityEngine;

namespace GruInject.API.Attributes
{
    public class GruMonoBehaviour : MonoBehaviour
    {
        private bool _wasInitialized = false;
        
        public void Awake()
        {
            if (!_wasInitialized)
            {
                _wasInitialized = true;
                InstanceInitializator.CurrentInstanceInitializator.InitializeGruInstance(this);
            }
        }
    }
}