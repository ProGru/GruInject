using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses.CircularDependency.CircularFreeClasses
{
    public class CircularFreeA
    {
        [AttributeForCircularDependencyDetection] private CircularFreeB _circularFreeB;

        [AttributeForCircularDependencyDetection] private CircularFreeC _circularFreeC;

        [AttributeForCircularDependencyDetection] private CircularFreeB _circularFreeBv2;
        [AttributeForCircularDependencyDetection] private CircularFreeB _circularFreeBv3 { get; }
    }
}