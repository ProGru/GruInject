using GruInject.Tests.AttributesForTests;

namespace GruInject.Tests.SupportClasses.Ctor
{
    public class ClassWithInjectedCtor2
    {
        public NormalRegisteredClassWithProperty _test1;
        public bool wasInitializedDurningCtor = false;
        
        [TestInject]
        public ClassWithInjectedCtor2(NormalRegisteredClassWithProperty test1)
        {
            _test1 = test1;
            wasInitializedDurningCtor = test1.isInitialized;
        }
    }
}