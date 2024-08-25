using System;
using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.GruInject.Example
{
    [RegisterInstance]
    public class SecondClassSignedForInjection : IDisposable
    {
        [Inject] public IThirdClassSignedForInjection ThirdClass;

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