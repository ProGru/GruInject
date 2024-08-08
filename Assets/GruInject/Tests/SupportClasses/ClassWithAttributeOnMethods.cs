using GruInject.API.Attributes;
using GruInject.Tests.Ctor;

namespace GruInject.Tests
{
    [RegisterAsSingleInstance]
    public class ClassWithAttributeOnMethods
    {
        public int NoParameterMethodWasCalled= 0;
        public int ParameterMethodWasCalled= 0;
        public ClassWithAttribute ParameterMethodValue;
        public int ParameterMethodWithReturnWasCalled= 0;
        public ClassWithAttribute ParameterMethodWithReturnValue;
        public int PrivateMethodWasCalled= 0;
        public int NoAttributeMethodWasCalled= 0;
        public int NoAttributeMethodWithInjectParamWasCalled= 0;
        public ClassWithAttribute NoAttributeMethodWithInjectParamValue;
        public int NoAttributeMethodWithInjectOnSecondParamWasCalled= 0;
        public ClassWithAttribute NoAttributeMethodWithInjectOnSecondParamValue1;
        public ClassWithAttribute NoAttributeMethodWithInjectOnSecondParamValue2;
        public int CtorCallsCount = 0;
        public ClassWithInjectedCtor _classWithInjectedCtor;
        public bool wasInjectedDurningMethodCall = false;

        [Inject]
        public ClassWithAttributeOnMethods()
        {
            CtorCallsCount++;
        }
        
        [Inject]
        public void NoParameterMethod()
        {
            NoParameterMethodWasCalled++;
        }

        [Inject]
        public void ParameterMethod(ClassWithAttribute value)
        {
            ParameterMethodWasCalled++;
            ParameterMethodValue = value;
        }

        [Inject]
        public ClassWithAttribute ParameterMethodWithReturn(ClassWithAttribute value)
        {
            ParameterMethodWithReturnWasCalled++;
            ParameterMethodWithReturnValue = value;
            return value;
        }

        [Inject]
        private void PrivateMethod()
        {
            PrivateMethodWasCalled++;
        }

        [Inject]
        private void ParameterMethodWithClass(ClassWithInjectedCtor classWithInjectedCtor)
        {
            _classWithInjectedCtor = classWithInjectedCtor;
            wasInjectedDurningMethodCall = _classWithInjectedCtor.wasInjectedClassInitializedDurningCotor;
        }

        public void NoAttributeMethod()
        {
            NoAttributeMethodWasCalled++;
        }

        public void NoAttributeMethodWithInjectParam([Inject] ClassWithAttribute value)
        {
            NoAttributeMethodWithInjectParamWasCalled++;
            NoAttributeMethodWithInjectParamValue = value;
        }
        
        public void NoAttributeMethodWithInjectOnSecondParam(ClassWithAttribute value1, [Inject] ClassWithAttribute value2)
        {
            NoAttributeMethodWithInjectOnSecondParamWasCalled++;
            NoAttributeMethodWithInjectOnSecondParamValue1 = value1;
            NoAttributeMethodWithInjectOnSecondParamValue2 = value2;
        }
    }
}