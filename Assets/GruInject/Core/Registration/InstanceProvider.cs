using System;
using System.Collections.Generic;
using System.Linq;
using GruInject.GruInject.Core.Injection;

namespace GruInject.GruInject.Core.Registration
{
    public class InstanceProvider : IInstanceProvider
    {
        private InstanceContainer _instanceContainer;
        private readonly AttributeCollector _attributeCollector = new();
        private readonly List<Type> _singleInstanceRuleDefinition = new();
        private readonly List<Type> _registeredInstances = new();
        private readonly Dictionary<Type, Type> _typeAssociatedInterfaces = new();
        private readonly bool _allowOnlyRegisteredInstances = false;
        private readonly InstanceCreator _instanceCreator;
        
        public InstanceProvider(bool allowOnlyRegisteredInstances, InstanceCreator instanceCreator,
            InstanceContainer instanceContainer, Type registerAsSingleAttribute, Type registerInstanceAttribute)
        {
            _instanceContainer = instanceContainer;
            _allowOnlyRegisteredInstances = allowOnlyRegisteredInstances;
            _instanceCreator = instanceCreator;

            var singleInstances = _attributeCollector.GetClasses(registerAsSingleAttribute);
            foreach (var type in singleInstances)
            {
                _singleInstanceRuleDefinition.Add(type);
                foreach (var associatedInterface in type.GetInterfaces())
                {
                    if (associatedInterface != typeof(IDisposable))
                    {
                        _typeAssociatedInterfaces.Add(associatedInterface, type);
                    }
                }
            }
            var registeredInstancesFound = _attributeCollector.GetClasses(registerInstanceAttribute);
            foreach (var type in registeredInstancesFound)
            {
                _registeredInstances.Add(type);
                foreach (var associatedInterface in type.GetInterfaces())
                {
                    if (associatedInterface != typeof(IDisposable))
                    {
                        _typeAssociatedInterfaces.Add(associatedInterface, type);
                    }
                }
            }
        }
        
        public object Get(Type type)
        {
            if (_allowOnlyRegisteredInstances)
            {
                if (!_registeredInstances.Contains(type) && !_singleInstanceRuleDefinition.Contains(type))
                    throw new Exception($"Trying to create unregistered Type: {type}");
            }

            if (_singleInstanceRuleDefinition.Contains(type))
            {
                if (_instanceContainer.InitializedInstances.TryGetValue(type, out var instance))
                {
                    return instance.First();
                }
            }

            return _instanceCreator.CreateInstance(type);
        }

        public Type GetAssociatedType(Type type)
        {
            if (type.IsInterface)
            {
                return _typeAssociatedInterfaces[type];
            }

            return type;
        }
        
        public object CheckInstanceAvailability(Type type)
        {
            if (_singleInstanceRuleDefinition.Contains(type))
            {
                if (_instanceContainer.InitializedInstances.TryGetValue(type, out var instance))
                {
                    return instance.First();
                }
            }

            return null;
        }

        public void Dispose()
        {
            _instanceContainer.Dispose();
        }
    }
}