using GruInject.Tests.AttributesForTests;
using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.MultiLayerInjectionClass
{
    [RegisterAsSingleInstanceForTest]
    public class TestClassLayer1
    {
        [FieldAndPropertyAttributeForTests] public TestClassLayer2 TestClassLayer2;
    }
}