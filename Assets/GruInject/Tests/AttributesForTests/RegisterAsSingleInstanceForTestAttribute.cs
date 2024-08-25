using System;

namespace GruInject.Tests.AttributesForTests
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class RegisterAsSingleInstanceForTestAttribute : Attribute
    {
    }
}