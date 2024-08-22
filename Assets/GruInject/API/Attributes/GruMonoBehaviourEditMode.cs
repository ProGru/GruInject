using UnityEngine;

namespace GruInject.API.Attributes
{
    [ExecuteInEditMode]
    public class GruMonoBehaviourEditMode : GruMonoBehaviour
    {
        private new void Awake()
        {
            if (InstanceInitialization.CurrentInstanceInitialization != null)
            {
                base.Awake();
            }
        }
    }
}