using GruInject.API.Attributes;

namespace GruInject.Tests.Ctor
{
    [AutoSpawn]
    public class NormalRegisteredClassWithProperty
    {
        public bool isInitialized = false;
        public NormalRegisteredClassWithProperty()
        {
            isInitialized = true;
        }
    }
}