namespace GruInject.Tests.CircularDependency
{
    public class CircularDependencyInCtorC
    {
        [AttributeForCircularDependencyDetection] private CircularDependencyInCtorA _circularDependencyA;
    }
}