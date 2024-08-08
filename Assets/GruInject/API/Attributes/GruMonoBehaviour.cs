using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.API
{
    public class GruMonoBehaviour : MonoBehaviour
    {
        private bool wasInitialized = false;
        private void Awake()
        {
            if (!wasInitialized)
                InstanceInitializator.CurrentInstanceInitializator.InitializeGruInstance(this);
        }
    }
}