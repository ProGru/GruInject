using GruInject.API.Attributes;
using GruInject.Tests.MultiLayerInjectionClass;

namespace GruInject.Tests
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