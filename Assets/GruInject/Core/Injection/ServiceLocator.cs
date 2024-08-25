using System;
using System.Collections.Generic;
using GruInject.API.Attributes;
using GruInject.GruInject.Core.Registration;

namespace GruInject.GruInject.Core.Injection
{
    public class ServiceLocator : IDisposable, IInstanceInitialization
    {
        private readonly IInstanceProvider _instanceProvider;
        private readonly InstanceFiller _instanceFiller;
        private readonly bool _enableCircularDependencyDetection;
        private readonly CircularDependencyDetection _circularDependencyDetection;
        private readonly List<Type> _injectAttributes;
        private readonly ServiceLocator _parentServiceLocator;
        private ServiceLocator _childServiceLocator;
        private InstanceContainer _instanceContainer;

        public ServiceLocator(List<Type> injectAttributes, Type registerAsSingleAttribute, Type registerInstance, bool enableCircularDependencyDetection, bool allowOnlyRegisteredInstances, ServiceLocator parentServiceLocator = null)
        {
            _parentServiceLocator = parentServiceLocator;
            _parentServiceLocator?.LinkAsChild(this);
            _injectAttributes = injectAttributes;
            _enableCircularDependencyDetection = enableCircularDependencyDetection;

            _instanceContainer = new InstanceContainer();
            _instanceProvider =  new InstanceProvider(allowOnlyRegisteredInstances, new InstanceCreator(), _instanceContainer, registerAsSingleAttribute, registerInstance);
            _instanceFiller = new InstanceFiller(injectAttributes, _instanceProvider);
            _circularDependencyDetection = new CircularDependencyDetection();
        }

        public ServiceLocator(List<Type> injectAttributes, InstanceContainer instanceContainer, IInstanceProvider instanceProvider, ServiceLocator parentServiceLocator = null)
        {
            _parentServiceLocator = parentServiceLocator;
            _parentServiceLocator?.LinkAsChild(this);
            _injectAttributes = injectAttributes;

            _instanceContainer = instanceContainer;
            _instanceProvider = instanceProvider;
            _instanceFiller = new InstanceFiller(injectAttributes, _instanceProvider);
            _circularDependencyDetection = new CircularDependencyDetection();
        }

        public T GetInstance<T>()
        {
            return (T) GetInstance(typeof(T));
        }
        
        public object GetInstance(Type type)
        {
            type = _instanceProvider.GetAssociatedType(type);
            if (_parentServiceLocator != null)
            {
                  var instance = _parentServiceLocator._instanceProvider.CheckInstanceAvailability(type);
                  if (instance != null) return instance;
            }
            
            if (_enableCircularDependencyDetection)
            {
                foreach (var attribute in _injectAttributes)
                {
                   var result = _circularDependencyDetection.FindCircularDependency(attribute, type);
                   if (result.Count > 0)
                   {
                       throw new Exception($"Circular dependency detected: {result}");
                   }
                }
            }

            var createdInstance = _instanceProvider.Get(type);
            _instanceFiller.FullyFillInstance(type, createdInstance);
            _instanceContainer.AddInstanceToContainer(type, createdInstance);
            return createdInstance;
        }

        public void InitializeGruInstance(GruMonoBehaviour monoBehaviour)
        {
            _instanceFiller.FillInstance(monoBehaviour);
            _instanceFiller.InitializeMethods(monoBehaviour);
        }

        private void LinkAsChild(ServiceLocator serviceLocator)
        {
            _childServiceLocator = serviceLocator;
        }

        public void Dispose()
        {
            _childServiceLocator?.Dispose();
            _instanceProvider.Dispose();
            _instanceFiller.Dispose();
        }
    }
}