
namespace GruInject.Tests.CircularDependency
{
    public class CircularDependencyB
    {
        [AttributeForCircularDependencyDetection] private CircularDependencyC _circularDependencyC;
    }
}