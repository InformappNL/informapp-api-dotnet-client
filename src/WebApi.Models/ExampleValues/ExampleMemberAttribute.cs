﻿using System;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Example member attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ExampleMemberAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="ExampleMemberAttribute"/> class.</summary>
        internal ExampleMemberAttribute()
        {

        }
    }
}
