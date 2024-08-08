using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.Example
{
    [RegisterInstance]
    public class SecondClassSignedForInjection
    {
        [Inject] public ThirdClassSignedForInjection ThirdClass;

        public SecondClassSignedForInjection()
        {
            Debug.Log($"I {this.GetType()} was injected");
        }
    }
}