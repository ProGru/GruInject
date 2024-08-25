using System;
using System.Collections.Generic;
using GruInject.API.Attributes;
using GruInject.GruInject.Core.Injection;

namespace GruInject.GruInject.API
{
    public class GruInject
    {
        private readonly List<Type> _autoSpawnAttributes;
        private readonly List<Type> _injectAttribute;
        private readonly Type _registerAsSingleAttribute;
        private readonly Type _registerInstanceAttribute;

        private ServiceLocator _serviceLocator;

        public GruInject()
        {
            _registerInstanceAttribute = typeof(RegisterInstanceAttribute);
            _registerAsSingleAttribute = typeof(RegisterAsSingleInstanceAttribute);
            _injectAttribute = new List<Type>() {typeof(InjectAttribute)};
            _autoSpawnAttributes = new List<Type>() {typeof(AutoSpawnAttribute)};
        }
        
        public GruInject(List<Type> autoSpawnAttributes, List<Type> injectAttribute, Type registerAsSingleAttribute, Type registerInstanceAttribute)
        {
            _registerInstanceAttribute = registerInstanceAttribute;
            _registerAsSingleAttribute = registerAsSingleAttribute;
            _injectAttribute = injectAttribute;
            _autoSpawnAttributes = autoSpawnAttributes;
        }

        public void Start(bool enableCircularDependencyDetection = false, bool allowOnlyRegisteredInstances = true)
        {
            if (_serviceLocator != null)
            {
                throw new Exception("Service already started");
            }

            _serviceLocator = new ServiceLocator(_injectAttribute, _registerAsSingleAttribute, _registerInstanceAttribute, enableCircularDependencyDetection, allowOnlyRegisteredInstances);
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

        public void Stop()
        {
            _serviceLocator.Dispose();
        }
    }
}