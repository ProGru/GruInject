
namespace GruInject.Tests.CircularDependency
{
    public class CircularDependencyC
    {
        [AttributeForCircularDependencyDetection] private CircularDependencyA _circularDependencyA;
    }
}