using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.CircularDependency
{
    public class CircularDependencyInCtorC
    {
        [AttributeForCircularDependencyDetection] private CircularDependencyInCtorA _circularDependencyA;
    }
}