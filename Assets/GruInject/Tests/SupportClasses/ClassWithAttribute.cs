using GruInject.Tests.AttributesForTests;
using GruInject.Tests.SupportClasses.Interfaces;
using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses
{
    [AttributeForTests]
    [RegisterInstanceForTest]
    public class ClassWithAttribute : IClassWithAttribute
    {
        
    }
}