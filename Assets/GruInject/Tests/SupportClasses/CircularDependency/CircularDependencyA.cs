using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.CircularDependency
{
    public class CircularDependencyA
    {
        [AttributeForCircularDependencyDetection] private CircularDependencyB _circularDependencyB;
    }
}