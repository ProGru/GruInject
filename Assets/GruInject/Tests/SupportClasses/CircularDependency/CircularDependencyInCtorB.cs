using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.CircularDependency
{
    public class CircularDependencyInCtorB
    {
        [AttributeForCircularDependencyDetection] private CircularDependencyInCtorC _circularDependencyInCtorC;
    }
}