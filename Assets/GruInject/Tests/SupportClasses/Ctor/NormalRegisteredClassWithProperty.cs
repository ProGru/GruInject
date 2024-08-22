using System;
using GruInject.API.Attributes;

namespace GruInject.Tests.SupportClasses.Ctor
{
    [AutoSpawn]
    public class NormalRegisteredClassWithProperty : IDisposable
    {
        public bool isInitialized = false;
        public NormalRegisteredClassWithProperty()
        {
            isInitialized = true;
        }

        public void Dispose()
        {
        }
    }
}