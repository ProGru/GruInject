using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.API
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