
namespace GruInject.Tests.CircularDependency
{
    public class CircularDependencyA
    {
        [AttributeForCircularDependencyDetection] private CircularDependencyB _circularDependencyB;
    }
}