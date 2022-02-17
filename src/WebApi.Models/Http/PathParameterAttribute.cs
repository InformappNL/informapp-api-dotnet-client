using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Marks a property as an URI parameter
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class PathParameterAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PathParameterAttribute"/> class.
        /// </summary>
        public PathParameterAttribute()
        {

        }
    }
}
