using System;

namespace GruInject.GruInject.Core.Registration
{
    public interface IInstanceProvider : IDisposable
    {
        object Get(Type type);
        Type GetAssociatedType(Type type);
        object CheckInstanceAvailability(Type type);
    }
}