using System;
using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.Example
{
    [RegisterInstance] //this is not as single so each request new instance will be created
    public class ClassSignedForInjection : IDisposable
    {
        [Inject] public SecondClassSignedForInjection SecondClass;

        public ClassSignedForInjection()
        {
            Debug.Log($"I {this.GetType()} was injected with {SecondClass.GetType()} and its initialized {SecondClass != null}");
        }

        public void Dispose()
        {
            SecondClass?.Dispose();
        }
    }
}