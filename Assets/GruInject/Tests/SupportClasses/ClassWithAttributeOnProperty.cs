namespace GruInject.Tests
{
    public class ClassWithAttributeOnProperty
    {
        [FieldAndPropertyAttributeForTests] public TestClassA TestClassA { get; set; }
        [FieldAndPropertyAttributeForTests] private TestClassA TestClassAPrivate { get; set; }
        [FieldAndPropertyAttributeForTests] public TestClassA TestClassAPrivateSet { get; private set; }
        [FieldAndPropertyAttributeForTests] public TestClassA TestClassAWithoutSet { get; }
        [FieldAndPropertyAttributeForTests] public TestClassA TestClassAWithPrivateGet { private get; set; }
    }
}