using UnityEngine;

namespace GruInject.API.Attributes
{
    [ExecuteInEditMode]
    public class GruMonoBehaviourEditMode : GruMonoBehaviour
    {
        private new void Awake()
        {
            if (InstanceInitializator.CurrentInstanceInitializator != null)
            {
                base.Awake();
            }
        }
    }
}