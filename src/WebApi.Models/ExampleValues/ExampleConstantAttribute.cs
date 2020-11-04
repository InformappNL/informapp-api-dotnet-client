using System;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Example constant attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ExampleConstantAttribute : ExampleAttribute
    {
        /// <summary>
        /// Kind
        /// </summary>
        public ExampleConstantKind Kind { get; }

        /// <summary>Initializes a new instance of the <see cref="ExampleConstantAttribute"/> class.</summary>
        public ExampleConstantAttribute(ExampleConstantKind kind)
        {
            Kind = kind;
        }
    }
}
