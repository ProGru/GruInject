﻿using System;
using GruInject.API.Attributes;

namespace GruInject.Tests.SupportClasses
{
    [RegisterAsSingleInstance]
    public class DisposableTestClassA : IDisposable
    {
        public int disposeCount;
        
        public void Dispose()
        {
            disposeCount ++;
        }
    }
}