namespace GruInject.Tests.CircularDependency
{
    public class CircularDependencyInCtorB
    {
        [AttributeForCircularDependencyDetection] private CircularDependencyInCtorC _circularDependencyInCtorC;
    }
}