namespace GruInject.Tests
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