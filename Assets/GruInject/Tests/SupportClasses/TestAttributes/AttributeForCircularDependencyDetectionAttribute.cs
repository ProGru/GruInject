using System;

namespace GruInject.Tests.SupportClasses.TestAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class AttributeForCircularDependencyDetectionAttribute : Attribute
    {
        
    }
}