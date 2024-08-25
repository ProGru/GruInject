using System;
using System.Collections.Generic;
using GruInject.API.Attributes;
using GruInject.GruInject.Core.Injection;
using GruInject.GruInject.Core.Registration;

namespace GruInject.GruInject.API.TestTools
{
    public class GruInjectForTests
    {
        private readonly List<Type> _autoSpawnAttributes;
        private readonly List<Type> _injectAttribute;

        private ServiceLocator _serviceLocator;

        public GruInjectForTests(List<Type> autoSpawnAttributes, List<Type> injectAttribute)
        {
            _injectAttribute = injectAttribute;
            _autoSpawnAttributes = autoSpawnAttributes;
        }

        public void Start(IInstanceProvider instanceProvider, InstanceContainer instanceContainer)
        {
            if (_serviceLocator != null)
            {
                throw new Exception("Service already started");
            }
            
            _serviceLocator = new ServiceLocator(_injectAttribute, instanceContainer,instanceProvider);
            InstanceInitialization.CurrentInstanceInitialization = _serviceLocator;

            AttributeCollector attributeCollector = new AttributeCollector();
            foreach (var attributeToSpawn in _autoSpawnAttributes)
            {
                IEnumerable<Type> classesToSpawn = attributeCollector.GetClasses(attributeToSpawn);

                foreach (var classToSpawn in classesToSpawn)
                {
                    _serviceLocator.GetInstance(classToSpawn);
                }
            }
        }
        
        public T GetInstance<T>()
        {
            return (T) _serviceLocator.GetInstance(typeof(T));
        }

        public void Stop()
        {
            _serviceLocator.Dispose();
        }
    }
}