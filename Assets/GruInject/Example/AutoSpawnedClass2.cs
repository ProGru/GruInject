using System;
using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.Example
{
    [AutoSpawn]// This attribute is inheritor of RegisterAsSingleInstanceAttribute so single instance will be spawn
    public class AutoSpawnedClass2 : IDisposable
    {
        [Inject] private AutoSpawnedClass1 _privateVariable;
        
        public AutoSpawnedClass2(AutoSpawnedClass1 param1)
        {
            Debug.Log($"I {this.GetType()} was spawned");
            Debug.Log($"My private variable {_privateVariable.GetType()} was initialized: {_privateVariable != null}");
            Debug.Log($"My param was of type {param1.GetType()} was initialized: {param1 != null}");
            Debug.Log($"And param and type were created as single: {param1 == _privateVariable}");
        }

        public void Dispose()
        {
        }
    }
}