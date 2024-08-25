using System;
using GruInject.Tests.AttributesForTests;

namespace GruInject.Tests.SupportClasses
{
    [RegisterAsSingleInstanceForTest]
    public class DisposableTestClassA : IDisposable
    {
        public int disposeCount;
        
        public void Dispose()
        {
            disposeCount ++;
        }
    }
}