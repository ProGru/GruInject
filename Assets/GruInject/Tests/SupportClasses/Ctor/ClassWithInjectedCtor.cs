using GruInject.Tests.AttributesForTests;

namespace GruInject.Tests.SupportClasses.Ctor
{
    public class ClassWithInjectedCtor
    {
        public ClassWithInjectedCtor2 _withInjectedCtor2;
        public bool wasInjectedClassInitializedDurningCotor = false;

        [TestInject]
        public ClassWithInjectedCtor(ClassWithInjectedCtor2 withInjectedCtor2)
        {
            _withInjectedCtor2 = withInjectedCtor2;
            wasInjectedClassInitializedDurningCotor = withInjectedCtor2.wasInitializedDurningCtor;
        }
    }
}