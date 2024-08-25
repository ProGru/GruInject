using System;
using GruInject.Tests.AttributesForTests;

namespace GruInject.Tests.SupportClasses
{
    [RegisterAsSingleInstanceForTest]
    public class DisposableTestClassB : IDisposable
    {
        public int disposeCount;

        public void Dispose()
        {
            disposeCount++;
        }
    }
}