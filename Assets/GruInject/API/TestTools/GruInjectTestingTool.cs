using System;
using System.Collections.Generic;
using GruInject.API.Attributes;
using GruInject.GruInject.Core.Injection;
using GruInject.GruInject.Core.Registration;

namespace GruInject.GruInject.API.TestTools
{
    public class GruInjectTestingTool : IDisposable
    {
        private readonly GruInjectForTests _gruInject;
        private readonly InstanceContainer _container;
        private readonly InstanceProviderForTest _instanceProvider;
        private readonly ServiceLocator _serviceLocator;
        private bool _started = false;

        public GruInjectTestingTool()
        {
            _gruInject = new GruInjectForTests(
                new List<Type>() {typeof(AutoSpawnAttribute)},
                new List<Type>() {typeof(InjectAttribute)});
            _container = new InstanceContainer();
            _instanceProvider = new InstanceProviderForTest(
                new InstanceProvider(
                    false, 
                    new InstanceCreator(), 
                    _container, 
                    typeof(RegisterAsSingleInstanceAttribute), 
                    typeof(RegisterInstanceAttribute)));
            
            _serviceLocator = new ServiceLocator(
                new List<Type>() 
                    {typeof(InjectAttribute)},typeof(RegisterAsSingleInstanceAttribute), typeof(RegisterInstanceAttribute), 
                false, true);
        }

        public T GetInstance<T>()
        {
            if (_started)
            {
                return _gruInject.GetInstance<T>();
            }
            return _serviceLocator.GetInstance<T>();
        }
        
        public void AddFakeInstance<T>(T instance)
        {
            _instanceProvider.AddFakeInstance(instance);
        }
        
        public void Start()
        {
            _started = true;
            _gruInject.Start(_instanceProvider, _container);
        }

        public void Dispose()
        {
            _serviceLocator.Dispose();
            _instanceProvider.ClearFakeInstances();
            if (_started)
                _gruInject.Stop();
        }
    }
}