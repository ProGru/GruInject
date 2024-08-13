using System;
using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.Example
{
    [RegisterInstance]
    public class ThirdClassSignedForInjection : IDisposable
    {
        public ThirdClassSignedForInjection()
        {
            Debug.Log($"I {this.GetType()} was injected");
        }

        public void Dispose()
        {
        }
    }
}