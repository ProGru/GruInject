using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.GruInject.Example
{
    [RegisterInstance]
    public class ThirdClassSignedForInjection : IThirdClassSignedForInjection
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