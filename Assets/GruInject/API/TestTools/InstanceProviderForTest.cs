using System;
using System.Collections.Generic;
using GruInject.GruInject.Core.Registration;

namespace GruInject.GruInject.API.TestTools
{
    public class InstanceProviderForTest : IInstanceProvider
    {
        private Dictionary<Type, object> _fakeInstances = new();
        private IInstanceProvider _basicProvider;

        public InstanceProviderForTest(IInstanceProvider basicProvider)
        {
            _basicProvider = basicProvider;
        }

        public void AddFakeInstance<T>(T instance)
        {
            _fakeInstances.Add(GetAssociatedType(typeof(T)), instance);
        }

        public void ClearFakeInstances()
        {
            _fakeInstances = new();
        }
        
        public object Get(Type type)
        {
            if (_fakeInstances.TryGetValue(type, out var instance))
            {
                return instance;
            }

            if (_fakeInstances.TryGetValue(GetAssociatedType(type), out var instanceFromInterface))
            {
                return instanceFromInterface;
            }

            return _basicProvider.Get(type);
        }

        public Type GetAssociatedType(Type type)
        {
            return _basicProvider.GetAssociatedType(type);
        }

        public object CheckInstanceAvailability(Type type)
        {
            if (_fakeInstances.ContainsKey(GetAssociatedType(type)))
            {
                return Get(type);
            }
            return _basicProvider.CheckInstanceAvailability(type);
        }

        public void Dispose()
        {
            _basicProvider.Dispose();
        }
    }
}