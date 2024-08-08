using System;
using System.Collections.Generic;
using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.Example
{
    [DefaultExecutionOrder(-999999999)]
    public class GruInjectStart : MonoBehaviour //ADD ME TO YOUR SCENE
    {
        private API.GruInject _gruInject;
        private void Awake()
        {
            _gruInject = new API.GruInject(
                new List<Type>() {typeof(AutoSpawnAttribute)},
                new List<Type>() {typeof(InjectAttribute)});
            _gruInject.Start();//Comment me if comment below is uncommented
            //_gruInject.Start(false, false); //Uncomment me to allow unregistered instances.
            //if you want to track circular dependencies set first parameter in Start to true.
        }
        
        private void OnDestroy()
        {
            _gruInject.Stop();
        }
    }
}