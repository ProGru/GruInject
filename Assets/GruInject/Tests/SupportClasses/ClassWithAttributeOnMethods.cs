using GruInject.API.Attributes;
using GruInject.Tests.InjectAttributesForTests;
using GruInject.Tests.SupportClasses.Ctor;

namespace GruInject.Tests.SupportClasses
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

        [TestInject]
        public ClassWithAttributeOnMethods()
        {
            CtorCallsCount++;
        }
        
        [TestInject]
        public void NoParameterMethod()
        {
            NoParameterMethodWasCalled++;
        }

        [TestInject]
        public void ParameterMethod(ClassWithAttribute value)
        {
            ParameterMethodWasCalled++;
            ParameterMethodValue = value;
        }

        [TestInject]
        public ClassWithAttribute ParameterMethodWithReturn(ClassWithAttribute value)
        {
            ParameterMethodWithReturnWasCalled++;
            ParameterMethodWithReturnValue = value;
            return value;
        }

        [TestInject]
        private void PrivateMethod()
        {
            PrivateMethodWasCalled++;
        }

        [TestInject]
        private void ParameterMethodWithClass(ClassWithInjectedCtor classWithInjectedCtor)
        {
            _classWithInjectedCtor = classWithInjectedCtor;
            wasInjectedDurningMethodCall = _classWithInjectedCtor.wasInjectedClassInitializedDurningCotor;
        }

        public void NoAttributeMethod()
        {
            NoAttributeMethodWasCalled++;
        }

        public void NoAttributeMethodWithInjectParam([TestInject] ClassWithAttribute value)
        {
            NoAttributeMethodWithInjectParamWasCalled++;
            NoAttributeMethodWithInjectParamValue = value;
        }
        
        public void NoAttributeMethodWithInjectOnSecondParam(ClassWithAttribute value1, [TestInject] ClassWithAttribute value2)
        {
            NoAttributeMethodWithInjectOnSecondParamWasCalled++;
            NoAttributeMethodWithInjectOnSecondParamValue1 = value1;
            NoAttributeMethodWithInjectOnSecondParamValue2 = value2;
        }
    }
}