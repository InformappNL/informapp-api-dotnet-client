using System;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Example string attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ExampleStringAttribute : ExampleAttribute
    {
        /// <summary>
        /// Kind
        /// </summary>
        public ExampleStringKind Kind { get; }

        /// <summary>
        /// String value
        /// </summary>
        public string StringValue { get; }

        /// <summary>Initializes a new instance of the <see cref="ExampleStringAttribute"/> class.</summary>
        internal ExampleStringAttribute(ExampleStringKind kind, string stringValue)
        {
            Kind = kind;

            StringValue = stringValue;
        }
    }
}
