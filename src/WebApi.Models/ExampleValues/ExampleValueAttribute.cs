using System;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Example value attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ExampleValueAttribute : ExampleAttribute
    {
        /// <summary>
        /// Value
        /// </summary>
        public object Value { get; }

        /// <summary>Initializes a new instance of the <see cref="ExampleValueAttribute"/> class.</summary>
        internal ExampleValueAttribute(object value)
        {
            Value = value;
        }
    }
}
