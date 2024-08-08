namespace GruInject.Tests.CircularDependency.CircularFreeClasses
{
    public class CircularFreeC
    {
        [AttributeForCircularDependencyDetection] private CircularFreeB _circularFreeB;

        [AttributeForCircularDependencyDetection] private CircularFreeD _circularFreeD;
    }
}