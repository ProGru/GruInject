using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GruInject.GruInject.Core.Registration;

namespace GruInject.GruInject.Core.Injection
{
    public class InstanceFiller : IDisposable
    {
        private readonly AttributeCollector _attributeCollector = new();
        private readonly List<Type> _injectAttributes;
        private IInstanceProvider _instanceProvider;

        public InstanceFiller(List<Type> injectAttributes, IInstanceProvider instanceProvider)
        {
            _instanceProvider = instanceProvider;
            _injectAttributes = injectAttributes;
        }

        public void FullyFillInstance<T>(Type type, T instance)
        {
            type = _instanceProvider.GetAssociatedType(type);
            FillInstance(instance);
            InitializeInstanceCtor(type, instance);
            InitializeMethods(instance);
        }

        public void FillInstance<T>(T instance)
        {
            foreach (var attribute in _injectAttributes)
            {
                var fields = _attributeCollector.GetFields(attribute, instance.GetType());
                foreach (var fieldInfo in fields)
                {
                    fieldInfo.SetValue(instance, GetFullyFilledInstance(fieldInfo.FieldType));
                }

                var properties = _attributeCollector.GetProperties(attribute, instance.GetType());
                foreach (var propertyInfo in properties)
                {
                    propertyInfo.SetValue(instance, GetFullyFilledInstance(propertyInfo.PropertyType));
                }
            }
        }

        public void InitializeMethods<T>(T instance)
        {
            foreach (var attribute in _injectAttributes)
            {
                var methods = _attributeCollector.GetMethods(attribute, instance.GetType());
                foreach (var methodInfo in methods)
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    var injectionServices = parameters
                        .Select(p => GetFullyFilledInstance(p.ParameterType))
                        .ToArray();
                    methodInfo.Invoke(instance, injectionServices);
                }

                var methodsWithAttributeOnParam =
                    _attributeCollector.GetMethodsWithAttributeOnParam(attribute, instance.GetType());
                
                foreach (var methodInfo in methodsWithAttributeOnParam)
                {
                    if (!methodInfo.IsDefined(attribute, false))
                    {
                        ParameterInfo[] parameters = methodInfo.GetParameters();
                        var injectionServices = parameters
                            .Select(p => GetFullyFilledInstance(p.ParameterType))
                            .ToArray();
                        methodInfo.Invoke(instance, injectionServices);
                    }
                }
            }
        }

        private object GetFullyFilledInstance(Type type)
        {
            type = _instanceProvider.GetAssociatedType(type);
            var instanceProvided = _instanceProvider.Get(type);
            FullyFillInstance(type, instanceProvided);
            return instanceProvided;
        }

        private void InitializeInstanceCtor(Type type, object instance)
        {
            var ctor = type.GetConstructors()
                           .Where(c => c.IsPublic)
                           .OrderByDescending(c => c.GetParameters().Length)
                           .FirstOrDefault()
                       ?? throw new InvalidOperationException($"No suitable constructor found on type '{type}'");

            
            var injectionServices = ctor.GetParameters()
                .Select(p => GetFullyFilledInstance(p.ParameterType))
                .ToArray();
            
            ctor.Invoke(instance, injectionServices);
        }

        public void Dispose()
        {
        }
    }
}