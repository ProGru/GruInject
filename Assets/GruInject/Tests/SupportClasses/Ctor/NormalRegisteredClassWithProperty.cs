using GruInject.API.Attributes;

namespace GruInject.Tests.SupportClasses.Ctor
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