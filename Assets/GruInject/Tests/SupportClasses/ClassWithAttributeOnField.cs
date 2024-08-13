using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses
{
    public class ClassWithAttributeOnField
    {
        [FieldAndPropertyAttributeForTests] public TestClassA field;
        [FieldAndPropertyAttributeForTests] private TestClassA _field;
        [FieldAndPropertyAttributeForTests] public TestClassA PublicField;
        [FieldAndPropertyAttributeForTests] private TestClassA _injectedField;
        public TestClassA InjectedFieldPrivateAccess => _injectedField;
    }
}