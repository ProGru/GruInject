using System;

namespace GruInject.Tests.AttributesForTests
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Parameter )]
    public class TestInjectAttribute : Attribute
    {
    }
}