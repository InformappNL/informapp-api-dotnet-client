using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Example JSON attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ExampleJsonAttribute : ExampleAttribute
    {
        /// <summary>
        /// Type
        /// </summary>
        public Type ModelType { get; }

        /// <summary>
        /// Json string
        /// </summary>
        public string JsonString { get; }

        /// <summary>Initializes a new instance of the <see cref="ExampleJsonAttribute"/> class.</summary>
        public ExampleJsonAttribute(Type modelType, string jsonString)
        {
            ModelType = modelType;

            JsonString = jsonString;
        }
    }
}
