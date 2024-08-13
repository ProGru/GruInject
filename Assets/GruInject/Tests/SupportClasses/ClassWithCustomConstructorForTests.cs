namespace GruInject.Tests.SupportClasses
{
    public class ClassWithCustomConstructorForTests
    {
        public TestClassA classAInstanceFromConstructor;

        public ClassWithCustomConstructorForTests(TestClassA classA)
        {
            classAInstanceFromConstructor = classA;
        }
    }
}