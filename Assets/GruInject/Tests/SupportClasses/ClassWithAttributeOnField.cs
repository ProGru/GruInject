using GruInject.Tests.SupportClasses.Interfaces;
using GruInject.Tests.SupportClasses.TestAttributes;

namespace GruInject.Tests.SupportClasses
{
    public class ClassWithAttributeOnField
    {
        [FieldAndPropertyAttributeForTests] public TestClassA field;
        [FieldAndPropertyAttributeForTests] private TestClassA _field;
        [FieldAndPropertyAttributeForTests] public TestClassA PublicField;
        [FieldAndPropertyAttributeForTests] private TestClassA _injectedField;
        
        [FieldAndPropertyAttributeForTests] public ITestInterfaceA fieldInterface;
        [FieldAndPropertyAttributeForTests] private ITestInterfaceA _fieldInterface;
        [FieldAndPropertyAttributeForTests] public ITestInterfaceA PublicFieldInterface;
        [FieldAndPropertyAttributeForTests] private ITestInterfaceA _injectedFieldInterface;
        public TestClassA InjectedFieldPrivateAccess => _injectedField;
        public ITestInterfaceA InjectedFieldPrivateAccessInterface => _injectedFieldInterface;
    }
}