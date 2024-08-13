using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.CircularDependency
{
    public class CircularDependencyB
    {
        [AttributeForCircularDependencyDetection] private CircularDependencyC _circularDependencyC;
    }
}