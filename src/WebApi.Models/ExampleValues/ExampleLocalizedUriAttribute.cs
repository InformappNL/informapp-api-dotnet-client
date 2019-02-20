using System;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Example localized uri attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ExampleLocalizedUriAttribute : ExampleAttribute
    {
        /// <summary>
        /// Path
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Query
        /// </summary>
        public string Query { get; }

        /// <summary>Initializes a new instance of the <see cref="ExampleConstantAttribute"/> class.</summary>
        internal ExampleLocalizedUriAttribute() : this(null, null)
        {

        }

        /// <summary>Initializes a new instance of the <see cref="ExampleConstantAttribute"/> class.</summary>
        internal ExampleLocalizedUriAttribute(string path) : this(path, null)
        {

        }

        /// <summary>Initializes a new instance of the <see cref="ExampleConstantAttribute"/> class.</summary>
        internal ExampleLocalizedUriAttribute(string path = null, string query = null)
        {
            Path = path;

            Query = query;
        }
    }
}
