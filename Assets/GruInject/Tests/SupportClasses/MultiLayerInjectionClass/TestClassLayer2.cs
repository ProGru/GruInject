using GruInject.Tests.AttributesForTests;
using GruInject.Tests.SupportClasses.Interfaces;
using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.MultiLayerInjectionClass
{
    [RegisterInstanceForTest]
    public class TestClassLayer2
    {
        [FieldAndPropertyAttributeForTests] public TestClassLayer3 TestClassLayer3 { get; private set; }
        [FieldAndPropertyAttributeForTests] public ITestInterfaceLayer3 TestInterfaceLayer3 { get; private set; }

    }
}