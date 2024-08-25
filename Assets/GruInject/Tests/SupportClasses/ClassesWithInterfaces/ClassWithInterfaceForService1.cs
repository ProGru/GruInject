using GruInject.Tests.AttributesForTests;
using GruInject.Tests.SupportClasses.Interfaces;

namespace GruInject.Tests.SupportClasses.ClassesWithInterfaces
{
    [RegisterAsSingleInstanceForTest]
    public class ClassWithInterfaceForService1 : IInterfaceForService1
    {
        
    }
}