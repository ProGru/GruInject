using GruInject.API.Attributes;
using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.MultiLayerInjectionClass
{
    [RegisterAsSingleInstance]
    public class TestClassLayer1
    {
        [FieldAndPropertyAttributeForTests] public TestClassLayer2 TestClassLayer2;
    }
}