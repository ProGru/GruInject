using System;
using System.Collections.Generic;
using GruInject.GruInject.Core.Injection;
using GruInject.Tests.AttributesForTests;
using GruInject.Tests.SupportClasses;
using GruInject.Tests.SupportClasses.Ctor;
using GruInject.Tests.SupportClasses.Interfaces;
using GruInject.Tests.SupportClasses.TestAttributes;
using NUnit.Framework;

namespace GruInject.Tests.InjectionTests
{
    public class ServiceLocatorTests
    {
        [SetUp]
        public void SetUp()
        {
                
        }

        [Test]
        public void When_InstanceRequested_Then_InstanceIsCreated()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);

            var insctance = serviceLocator.GetInstance<TestClassA>();
            
            Assert.IsNotNull(insctance);
        }

        [Test]
        public void When_RequestingInstanceThatWasRequestedBefore_Then_TheSameInstanceIsRequested()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var firstInstanceRequest = serviceLocator.GetInstance<TestClassA>();
            var secondInstanceRequest = serviceLocator.GetInstance<TestClassA>();
            
            Assert.AreSame(firstInstanceRequest, secondInstanceRequest);
        }
        
        [Test]
        public void When_RequestingInstanceByInterfaceThatWasRequestedBefore_Then_TheSameInstanceIsRequested()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var firstInstanceRequest = serviceLocator.GetInstance<ITestInterfaceA>();
            var secondInstanceRequest = serviceLocator.GetInstance<ITestInterfaceA>();
            
            Assert.AreSame(firstInstanceRequest, secondInstanceRequest);
        }

        [Test]
        public void When_RequestingClassWithInjectOnPrivateField_Then_InstanceIsCreatedAndFieldsWithInjectAreFilled()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute), false, false);
            var result = serviceLocator.GetInstance<ClassWithAttributeOnField>();
            
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.InjectedFieldPrivateAccess);
        }
        
        [Test]
        public void When_RequestingClassWithInjectOnPrivateFieldThatIsInterface_Then_InstanceIsCreatedAndFieldsWithInjectAreFilled()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute), false, false);
            var result = serviceLocator.GetInstance<ClassWithAttributeOnField>();
            
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.InjectedFieldPrivateAccessInterface);
        }
        
        [Test]
        public void When_RequestingClassWithInjectOnPublicField_Then_InstanceIsCreatedAndFieldsWithInjectAreFilled()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute), false, false);
            var result = serviceLocator.GetInstance<ClassWithAttributeOnField>();
            
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PublicField);
        }
        
        [Test]
        public void When_RequestingClassWithInjectOnPublicFieldThatIsInterface_Then_InstanceIsCreatedAndFieldsWithInjectAreFilled()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute), false, false);
            var result = serviceLocator.GetInstance<ClassWithAttributeOnField>();
            
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PublicFieldInterface);
        }

        [Test]
        public void
            When_RequestingClassMarkedWithRegisterInstanceAttributeTwice_Then_InstancesAreCreatedAndAreDifferent()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var firstInstanceRequest = serviceLocator.GetInstance<RegisteredInstanceClassForTest>();
            var secondInstanceRequest = serviceLocator.GetInstance<RegisteredInstanceClassForTest>();
            
            Assert.IsNotNull(firstInstanceRequest);
            Assert.IsNotNull(secondInstanceRequest);
            Assert.AreNotSame(firstInstanceRequest, secondInstanceRequest);
        }
        
        [Test]
        public void
            When_RequestingInterfaceMarkedWithRegisterInstanceAttributeTwice_Then_InstancesAreCreatedAndAreDifferent()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var firstInstanceRequest = serviceLocator.GetInstance<IRegisteredInstanceForTest>();
            var secondInstanceRequest = serviceLocator.GetInstance<IRegisteredInstanceForTest>();
            var firstInstanceRequestClass = serviceLocator.GetInstance<RegisteredInstanceClassForTest>();
            
            Assert.IsNotNull(firstInstanceRequest);
            Assert.IsNotNull(secondInstanceRequest);
            Assert.IsNotNull(firstInstanceRequestClass);
            Assert.AreNotSame(firstInstanceRequest, secondInstanceRequest);
            Assert.AreNotSame(firstInstanceRequest,firstInstanceRequestClass);
            Assert.AreNotSame(secondInstanceRequest,firstInstanceRequestClass);
        }

        [Test]
        public void When_RequestingClassWithOnlyCustomConstructor_Then_InstanceIsCreated()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var result = serviceLocator.GetInstance<ClassWithCustomConstructorForTests>();
            
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.classAInstanceFromConstructor);
        }

        [Test]
        public void
            When_RequestingClassWithCustomConstructorThatHaveInjectedFields_Then_InstanceIsCreatedAndAllInjectedFieldsAreInjectedAndThoseClassChildsAreAlsoInjected()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var result = serviceLocator.GetInstance<ClassWithCustomAttributeForLayerTest>();
            
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.testClassAFromCtor);
            Assert.IsNotNull(result.testClassLayer1);
            Assert.IsNotNull(result.testClassLayer1.TestClassLayer2);
            Assert.IsNotNull(result.testClassLayer1.TestClassLayer2.TestClassLayer3);
            Assert.IsNotNull(result.testClassLayer1.TestClassLayer2.TestInterfaceLayer3);
        }

        [Test]
        public void
            When_UsingLinkedServiceLocatorAccessingInstanceTwiceBetweenLocatorCreation_Then_TheSameInstanceIsReturnedForAsSingle()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var firstInstanceRequest = serviceLocator.GetInstance<TestClassA>();
            ServiceLocator secondServiceLocator = new(new List<Type>(){typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false,false, serviceLocator);
            var secondInstanceRequest = secondServiceLocator.GetInstance<TestClassA>();
            var secondInstanceRequestInterface = secondServiceLocator.GetInstance<ITestInterfaceA>();
            
            Assert.AreSame(firstInstanceRequest, secondInstanceRequest);
            Assert.AreSame(firstInstanceRequest, secondInstanceRequestInterface);
        }

        [Test]
        public void When_DisposeServiceLocator_Then_AllInstanceCreatedByThisSLAreDisposed()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var firstInstanceRequest = serviceLocator.GetInstance<DisposableTestClassA>();
            
            serviceLocator.Dispose();
            Assert.AreEqual(1,firstInstanceRequest.disposeCount);
        }

        [Test]
        public void When_DisposeLinkedServiceLocator_Then_AllInstancesCreatedAreDisposedWhenDisposingParentSL()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var firstInstanceRequest = serviceLocator.GetInstance<DisposableTestClassA>();
            ServiceLocator secondServiceLocator = new(new List<Type>(){typeof(FieldAndPropertyAttributeForTestsAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false, false, serviceLocator);
            var secondInstanceRequest = secondServiceLocator.GetInstance<DisposableTestClassB>();
            serviceLocator.Dispose();
            
            Assert.AreEqual(1,firstInstanceRequest.disposeCount);
            Assert.AreEqual(1,secondInstanceRequest.disposeCount);
        }

        [Test]
        public void When_CreatingInstanceWithAttributeOnMethod_Then_MethodIsCalledAndAllParametersAreInjected()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(TestInjectAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var requestedInstance = serviceLocator.GetInstance<ClassWithAttributeOnMethods>();
            serviceLocator.GetInstance<ClassWithAttributeOnMethods>();
            
            Assert.IsTrue(requestedInstance.NoParameterMethodWasCalled == 1);
            Assert.IsTrue(requestedInstance.ParameterMethodWasCalled == 1);
            Assert.IsTrue(requestedInstance.ParameterMethodWithInterfaceWasCalled == 1);
            Assert.IsTrue(requestedInstance.ParameterMethodInterfaceValue != null);
            Assert.IsTrue(requestedInstance.ParameterMethodValue != null);
            Assert.IsTrue(requestedInstance.ParameterMethodWithReturnWasCalled == 1);
            Assert.IsTrue(requestedInstance.ParameterMethodWithReturnValue != null);
            Assert.IsTrue(requestedInstance.PrivateMethodWasCalled == 1);
            
            Assert.IsFalse(requestedInstance.NoAttributeMethodWasCalled != 0);
            
            Assert.IsTrue(requestedInstance.NoAttributeMethodWithInjectParamWasCalled == 1);
            Assert.IsTrue(requestedInstance.NoAttributeMethodWithInjectParamValue != null);
            Assert.IsTrue(requestedInstance.NoAttributeMethodWithInjectOnSecondParamWasCalled == 1);
            Assert.IsTrue(requestedInstance.NoAttributeMethodWithInjectOnSecondParamValue1 != null);
            Assert.IsTrue(requestedInstance.NoAttributeMethodWithInjectOnSecondParamValue2 != null);
            Assert.IsTrue(requestedInstance.CtorCallsCount == 1);
        }
        
        [Test]
        public void When_CreatingInstanceWithAttributeOnCtor_Then_CtorIsCalledAndAllParametersAreInjectedWhenInitialized()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(TestInjectAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var requestedInstance = serviceLocator.GetInstance<ClassWithInjectedCtor>();

            Assert.IsTrue(requestedInstance.wasInjectedClassInitializedDurningCotor);
            Assert.IsTrue(requestedInstance._withInjectedCtor2 != null);
            Assert.IsTrue(requestedInstance._withInjectedCtor2.wasInitializedDurningCtor);
            Assert.IsTrue(requestedInstance._withInjectedCtor2._test1.isInitialized);
            
        }
        
        [Test]
        public void When_CreatingInstanceWithAttributeOnMethod_Then_MethodIsCalledAndAllParametersAreInjectedWhenInitialized()
        {
            ServiceLocator serviceLocator = new(new List<Type>() {typeof(TestInjectAttribute)}, typeof(RegisterAsSingleInstanceForTestAttribute), typeof(RegisterInstanceForTestAttribute),false, false);
            var requestedInstance = serviceLocator.GetInstance<ClassWithAttributeOnMethods>();

            Assert.IsTrue(requestedInstance._classWithInjectedCtor != null);
            Assert.IsTrue(requestedInstance._classWithInjectedCtor._withInjectedCtor2.wasInitializedDurningCtor);
            Assert.IsTrue(requestedInstance._classWithInjectedCtor._withInjectedCtor2._test1.isInitialized);
        }
    }
}