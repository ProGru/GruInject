using GruInject.API.Attributes;
using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.MultiLayerInjectionClass
{
    [RegisterInstance]
    public class TestClassLayer2
    {
        [FieldAndPropertyAttributeForTests] public TestClassLayer3 TestClassLayer3 { get; private set; }
    }
}