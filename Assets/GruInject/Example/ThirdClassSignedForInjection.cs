using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.Example
{
    [RegisterInstance]
    public class ThirdClassSignedForInjection
    {
        public ThirdClassSignedForInjection()
        {
            Debug.Log($"I {this.GetType()} was injected");
        }
    }
}