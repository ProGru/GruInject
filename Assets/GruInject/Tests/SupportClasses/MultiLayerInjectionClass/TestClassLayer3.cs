using GruInject.Tests.AttributesForTests;
using GruInject.Tests.SupportClasses.Interfaces;

namespace GruInject.Tests.SupportClasses.MultiLayerInjectionClass
{
    [RegisterInstanceForTest]
    public class TestClassLayer3 : ITestInterfaceLayer3
    {
        
    }
}