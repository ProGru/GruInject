using GruInject.API.Attributes;

namespace GruInject.Tests.MultiLayerInjectionClass
{
    [RegisterAsSingleInstance]
    public class TestClassLayer1
    {
        [FieldAndPropertyAttributeForTests] public TestClassLayer2 TestClassLayer2;
    }
}