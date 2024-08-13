using System;
using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.Example
{
    [RegisterInstance]
    public class SecondClassSignedForInjection : IDisposable
    {
        [Inject] public ThirdClassSignedForInjection ThirdClass;

        public SecondClassSignedForInjection()
        {
            Debug.Log($"I {this.GetType()} was injected");
        }

        public void Dispose()
        {
            ThirdClass?.Dispose();
        }
    }
}