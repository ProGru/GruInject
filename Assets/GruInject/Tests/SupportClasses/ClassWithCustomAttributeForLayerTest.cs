using GruInject.API.Attributes;
using GruInject.Tests.SupportClasses.MultiLayerInjectionClass;
using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses
{
    [RegisterInstance]
    public class ClassWithCustomAttributeForLayerTest
    {
        [FieldAndPropertyAttributeForTests] public TestClassLayer1 testClassLayer1;
        public TestClassA testClassAFromCtor;

        public ClassWithCustomAttributeForLayerTest(TestClassA testClassA)
        {
            testClassAFromCtor = testClassA;
        }
    }
}