using UnityEngine;

namespace GruInject.GruInject.Example
{
    [DefaultExecutionOrder(-999999999)]
    [ExecuteInEditMode]
    public class GruInjectStart : MonoBehaviour
    {
        [Tooltip("This option allow you to use Injection in EditMode -" +
                 " It will work only if all your services that auto start can work in edit mode and your object implements [GruMonoBehaviourEditMode]" + 
                 "IMPORTANT - after selecting reload scene!")]
        public bool allowInEditorMode = false;
        
        private API.GruInject _gruInject;
        
        private void Awake()
        {
            if (!Application.isPlaying && !allowInEditorMode)
            {
                return;
            }
            _gruInject = new API.GruInject();
            _gruInject.Start();
        }
        
        private void OnDestroy()
        {
            _gruInject?.Stop();
        }
    }
}