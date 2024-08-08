using System;
using System.Collections.Generic;
using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.Example
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
            _gruInject = new API.GruInject(
                new List<Type>() {typeof(AutoSpawnAttribute)},
                new List<Type>() {typeof(InjectAttribute)});
            _gruInject.Start();//Comment me if comment below is uncommented
            //_gruInject.Start(false, false); //Uncomment me to allow unregistered instances.
            //if you want to track circular dependencies set first parameter in Start to true.
        }
        
        private void OnDestroy()
        {
            _gruInject?.Stop();
        }
    }
}