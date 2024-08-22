using System;
using System.Collections.Generic;
using GruInject.API.Attributes;
using GruInject.Core.Registration;

namespace GruInject.Core.Injection
{
    public class ServiceLocator : IDisposable, IInstanceInitialization
    {
        private readonly InstanceProvider _instanceProvider;
        private readonly InstanceFiller _instanceFiller;
        private readonly bool _enableCircularDependencyDetection;
        private readonly CircularDependencyDetection _circularDependencyDetection;
        private readonly List<Type> _injectAttributes;
        private readonly ServiceLocator _parentServiceLocator;
        private ServiceLocator _childServiceLocator;

        public ServiceLocator(List<Type> injectAttributes, bool enableCircularDependencyDetection, bool allowOnlyRegisteredInstances, ServiceLocator parentServiceLocator = null)
        {
            _parentServiceLocator = parentServiceLocator;
            _parentServiceLocator?.LinkAsChild(this);
            _injectAttributes = injectAttributes;
            _enableCircularDependencyDetection = enableCircularDependencyDetection;
            _instanceFiller = new InstanceFiller(injectAttributes);
            _instanceProvider =  new InstanceProvider(allowOnlyRegisteredInstances, _instanceFiller);
            _circularDependencyDetection = new CircularDependencyDetection();
        }
        
        public T GetInstance<T>()
        {
            return (T) GetInstance(typeof(T));
        }
        
        public object GetInstance(Type type)
        {
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

            return _instanceProvider.Get(type);
        }

        public void InitializeGruInstance(GruMonoBehaviour monoBehaviour)
        {
            _instanceFiller.FillInstance(monoBehaviour, _instanceProvider.Get);
            _instanceFiller.InitializeMethods(monoBehaviour,_instanceProvider.Get);
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