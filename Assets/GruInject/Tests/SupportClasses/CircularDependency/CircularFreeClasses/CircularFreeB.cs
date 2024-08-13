using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.CircularDependency.CircularFreeClasses
{
    public class CircularFreeB
    {
        [AttributeForCircularDependencyDetection] private CircularFreeD _circularFreeD;
    }
}