using System;
using System.Runtime.CompilerServices;

namespace GruInject.GruInject.Core.Registration
{
    public class InstanceCreator
    {
        public object CreateInstance(Type type)
        {
            var createdInstance = CreateNotCtorInstance(type);
            return createdInstance;
        }
        
        private object CreateNotCtorInstance(Type type)
        {
            return RuntimeHelpers.GetUninitializedObject(type);
        }
    }
}