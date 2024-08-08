namespace GruInject.Tests.CircularDependency.CircularFreeClasses
{
    public class CircularFreeB
    {
        [AttributeForCircularDependencyDetection] private CircularFreeD _circularFreeD;
    }
}