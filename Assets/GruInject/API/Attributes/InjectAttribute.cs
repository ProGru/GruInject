﻿using System;

namespace GruInject.API.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Parameter )]
    public class InjectAttribute : Attribute
    {
        /***
        Fields and Properties with this attribute will be injected with instances,
        if the class they are part of is created with Service allocation (Either create due injection or by ServiceLocator.GetInstance
        
        If used on a method or param of a method then this method will be called when an instance is created.
        all params will be filled even if the attribute is used only on one of them
        ***/
    }
}