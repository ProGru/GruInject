using System;
using System.Linq;
using System.Reflection;
using GruInject.Core.Injection;
using GruInject.Tests.InjectAttributesForTests;
using GruInject.Tests.SupportClasses;
using GruInject.Tests.SupportClasses.TestAttributes;
using NUnit.Framework;

namespace GruInject.Tests.InjectionTests
{
    public class AttributeCollectorTests
    {

        [Test]
        public void When_RequestingClassesWithAttribute_Then_ReturnAllClassesWithAttribute()
        {
            AttributeCollector attributeCollector = new();

            var result = attributeCollector.GetClasses(typeof(AttributeForTestsAttribute));
            
            Assert.True(result.Contains(typeof(ClassWithAttribute)));
            Assert.False(result.Contains(typeof(ClassWithoutAttribute)));
        }

        [Test]
        public void WhenRequestingFieldsAttributesForType_Then_AllFieldsWithAttributeForThisTypeAreReturned()
        {
            AttributeCollector attributeCollector = new();
            var result =
                attributeCollector.GetFields(typeof(FieldAndPropertyAttributeForTestsAttribute) ,typeof(ClassWithAttributeOnField));

            Type type = typeof(ClassWithAttributeOnField);
            var expectedFields = type.GetFields( BindingFlags.NonPublic | BindingFlags.Public| BindingFlags.Instance).
                Where(x => x.IsDefined(typeof(FieldAndPropertyAttributeForTestsAttribute)));
            
            Assert.IsNotEmpty(expectedFields);
            foreach (var fieldInfo in expectedFields)
            {
                Assert.Contains(fieldInfo, result);    
            }
        }

        [Test]
        public void WhenRequestingPropertiesAttributesForType_Then_AllPropertiesWithAttributeForThisTypeAreReturned()
        {
            AttributeCollector attributeCollector = new();
            var result =
                attributeCollector.GetProperties(typeof(FieldAndPropertyAttributeForTestsAttribute), typeof(ClassWithAttributeOnProperty));

            Type type = typeof(ClassWithAttributeOnProperty);
            var expectedProperties = type.GetProperties( BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).
                Where(x => x.IsDefined(typeof(FieldAndPropertyAttributeForTestsAttribute)));
            
            Assert.IsNotEmpty(expectedProperties);
            foreach (var propertyInfo in expectedProperties)
            {
                Assert.Contains(propertyInfo, result);    
            }
        }

        [Test]
        public void WhenRequestingMethodAttributesForType_Then_AllMethodsWithAttributeForThisTypeAreReturned()
        {
            AttributeCollector attributeCollector = new();
            var result = attributeCollector.GetMethods(typeof(TestInjectAttribute), typeof(ClassWithAttributeOnMethods));

            Assert.True(result.Find(x =>x.Name == "NoParameterMethod") != null);
            Assert.True(result.Find(x =>x.Name == "ParameterMethod") != null);
            Assert.True(result.Find(x =>x.Name == "ParameterMethodWithReturn") != null);
            Assert.True(result.Find(x =>x.Name == "PrivateMethod") != null);
            
            Assert.False(result.Find(x =>x.Name == "NoAttributeMethod") != null);
        }
        
        [Test]
        public void WhenRequestingMethodWithAttributesOnParamsForType_Then_AllMethodsWithAttributeForThisTypeAreReturned()
        {
            AttributeCollector attributeCollector = new();
            var result = attributeCollector.GetMethodsWithAttributeOnParam(typeof(TestInjectAttribute), typeof(ClassWithAttributeOnMethods));

            Assert.False(result.Find(x =>x.Name == "NoParameterMethod") != null);
            Assert.False(result.Find(x =>x.Name == "ParameterMethod") != null);
            Assert.False(result.Find(x =>x.Name == "ParameterMethodWithReturn") != null);
            Assert.False(result.Find(x =>x.Name == "PrivateMethod") != null);
            
            Assert.False(result.Find(x =>x.Name == "NoAttributeMethod") != null);
            
            Assert.True(result.Find(x =>x.Name == "NoAttributeMethodWithInjectParam") != null);
            Assert.True(result.Find(x =>x.Name == "NoAttributeMethodWithInjectOnSecondParam") != null);
        }
    }
}