using GruInject.API.Attributes;

namespace GruInject.Tests.Ctor
{
    public class ClassWithInjectedCtor2
    {
        public NormalRegisteredClassWithProperty _test1;
        public bool wasInitializedDurningCtor = false;
        
        [Inject]
        public ClassWithInjectedCtor2(NormalRegisteredClassWithProperty test1)
        {
            _test1 = test1;
            wasInitializedDurningCtor = test1.isInitialized;
        }
    }
}