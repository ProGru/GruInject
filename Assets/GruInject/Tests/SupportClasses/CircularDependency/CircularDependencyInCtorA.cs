﻿
namespace GruInject.Tests.CircularDependency
{
    public class CircularDependencyInCtorA
    {
        private CircularDependencyInCtorB _circularDependencyB;

        public CircularDependencyInCtorA(CircularDependencyInCtorB circularDependencyB)
        {
            _circularDependencyB = circularDependencyB;
        }
    }
}