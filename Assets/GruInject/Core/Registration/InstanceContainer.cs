using System;
using System.Collections.Generic;
using GruInject.GruInject.Core.Helpers;
using UnityEngine;

namespace GruInject.GruInject.Core.Registration
{
    public class InstanceContainer : IDisposable
    {
        public Dictionary<Type, List<object>> InitializedInstances = new();
        private readonly bool _suppressDisposeWarnings;

        public InstanceContainer(bool suppressDisposeWarnings = false)
        {
            _suppressDisposeWarnings = suppressDisposeWarnings;
        }

        public void AddInstanceToContainer(Type type, object instance)
        {
            if (InitializedInstances.TryGetValue(type, out List<object> litOfInstances))
            {
                litOfInstances.Add(instance);
            }
            else
            {
                foreach (var associatedInterface in type.GetInterfaces())
                {
                    if (associatedInterface != typeof(IDisposable))
                    {
                        if (InitializedInstances.TryGetValue(associatedInterface, out List<object> listOfInterfaceInstances))
                            listOfInterfaceInstances.Add(associatedInterface);
                        else
                        {
                            InitializedInstances.Add(associatedInterface,new List<object>() {instance});

                        }
                    }
                }
                InitializedInstances.Add(type, new List<object>() {instance});
            }
        }
        
        public void Dispose()
        {
            foreach (var instance in InitializedInstances)
            {
                if (typeof(IDisposable).IsAssignableFrom(instance.Key))
                {
                    foreach (IDisposable element in instance.Value)
                    {
                        if (!DisposeChecker.IsDisposed(element))
                            element.Dispose();
                        else
                        {
                            if(!_suppressDisposeWarnings)
                                Debug.LogWarning($"Found not disposed instance while closing GruInj of type: {instance.Key}");
                        }
                    }
                }
                else
                {
                    if (!_suppressDisposeWarnings)
                        Debug.LogWarning($"Type {instance.Key} don't implement IDisposable - It lends to memory leak. Found {instance.Value.Count} instances not Disposed.");
                }
            }

            InitializedInstances = null;
        }
    }
}