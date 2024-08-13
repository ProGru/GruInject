using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.CircularDependency
{
    public class CircularDependencyC
    {
        [AttributeForCircularDependencyDetection] private CircularDependencyA _circularDependencyA;
    }
}