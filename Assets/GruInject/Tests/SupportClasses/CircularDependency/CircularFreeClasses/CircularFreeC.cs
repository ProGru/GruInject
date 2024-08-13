using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.CircularDependency.CircularFreeClasses
{
    public class CircularFreeC
    {
        [AttributeForCircularDependencyDetection] private CircularFreeB _circularFreeB;

        [AttributeForCircularDependencyDetection] private CircularFreeD _circularFreeD;
    }
}