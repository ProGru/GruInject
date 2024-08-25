﻿using GruInject.Tests.AttributesForTests;
using GruInject.Tests.SupportClasses.Interfaces;

namespace GruInject.Tests.SupportClasses
{
    [RegisterAsSingleInstanceForTest]
    public class TestClassA : ITestInterfaceA
    {
        
    }
}