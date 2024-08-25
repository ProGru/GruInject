using System;
using System.Collections.Generic;
using GruInject.API.Attributes;
using GruInject.Example.PersistenceOperations.API;

namespace GruInject.Example.PersistenceOperations.Service
{
    [RegisterAsSingleInstance]
    public class StaticPersistenceService : IPersistenceSaver, IPersistenceLoader, IDisposable
    {
        private static Dictionary<string, int> _staticPersistence = new();

        public void SaveData(string key, int data)
        {
            _staticPersistence[key] = data;
        }

        public int GetData(string key, int defaultValue)
        {
            if (_staticPersistence.TryGetValue(key, out var data))
            {
                return data;
            }

            return defaultValue;
        }

        public void Dispose()
        {
        }
    }
}