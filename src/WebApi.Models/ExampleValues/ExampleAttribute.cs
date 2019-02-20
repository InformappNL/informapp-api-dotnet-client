using System;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Base class for example attributes
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public abstract class ExampleAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="ExampleAttribute"/> class.</summary>
        internal ExampleAttribute()
        {

        }
    }
}
