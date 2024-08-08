using System;

namespace GruInject.Tests
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class AttributeForCircularDependencyDetectionAttribute : Attribute
    {
        
    }
}