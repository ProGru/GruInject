using GruInject.API.Attributes;

namespace GruInject.Tests.MultiLayerInjectionClass
{
    [RegisterInstance]
    public class TestClassLayer2
    {
        [FieldAndPropertyAttributeForTests] public TestClassLayer3 TestClassLayer3 { get; private set; }
    }
}