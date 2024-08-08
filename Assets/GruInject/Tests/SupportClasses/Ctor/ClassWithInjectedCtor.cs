using GruInject.API.Attributes;
using NUnit.Framework.Constraints;

namespace GruInject.Tests.Ctor
{
    public class ClassWithInjectedCtor
    {
        public ClassWithInjectedCtor2 _withInjectedCtor2;
        public bool wasInjectedClassInitializedDurningCotor = false;

        [Inject]
        public ClassWithInjectedCtor(ClassWithInjectedCtor2 withInjectedCtor2)
        {
            _withInjectedCtor2 = withInjectedCtor2;
            wasInjectedClassInitializedDurningCotor = withInjectedCtor2.wasInitializedDurningCtor;
        }
    }
}