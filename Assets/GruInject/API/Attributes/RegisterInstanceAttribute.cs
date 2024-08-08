﻿using System;

namespace GruInject.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class RegisterInstanceAttribute : Attribute
    {
        //Classes and Struct with this attribute will have instance created per request of instance.
    }
}