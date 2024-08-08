using System;

namespace GruInject.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class RegisterAsSingleInstanceAttribute : Attribute
    {
        //Classes and struct with this attribute will be created only once and single instance will be distributed.
    }
}