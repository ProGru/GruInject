using GruInject.Tests.AttributesForTests;
using GruInject.Tests.SupportClasses.MultiLayerInjectionClass;
using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses
{
    [RegisterInstanceForTest]
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