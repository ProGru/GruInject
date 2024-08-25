using GruInject.GruInject.Core.Injection;
using GruInject.Tests.SupportClasses.CircularDependency;
using GruInject.Tests.SupportClasses.CircularDependency.CircularFreeClasses;
using GruInject.Tests.SupportClasses.TestAttributes;
using NUnit.Framework;

namespace GruInject.Tests.InjectionTests
{
    public class CircularDependencyDetectionTests
    {

        [Test]
        public void When_CircularDependencyExistInInject_Then_ListOfClassInCircleIsReturned()
        {
            CircularDependencyDetection circularDependencyDetection = new();
            var result = circularDependencyDetection.FindCircularDependency(typeof(AttributeForCircularDependencyDetectionAttribute), typeof(CircularDependencyA));
            
            Assert.AreEqual(4,result.Count);
        }

        [Test]
        public void When_CorrectInjection_Then_EmptyListIsReturned()
        {
            CircularDependencyDetection circularDependencyDetection = new();
            var result = circularDependencyDetection.FindCircularDependency(typeof(AttributeForCircularDependencyDetectionAttribute), typeof(CircularFreeA));
            Assert.IsEmpty(result);
        }

        [Test]
        public void When_CircularDependencyExistInCtor_Then_ListOfClassInCircleIsReturned()
        {
            CircularDependencyDetection circularDependencyDetection = new();
            var result = circularDependencyDetection.FindCircularDependency(typeof(AttributeForCircularDependencyDetectionAttribute), typeof(CircularDependencyInCtorA));
            Assert.AreEqual(4,result.Count);
        }
    }
}