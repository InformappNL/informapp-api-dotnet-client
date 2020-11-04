using System;

namespace Informapp.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Marks a property as body parameter
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class BodyParameterAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyParameterAttribute"/> class.
        /// </summary>
        public BodyParameterAttribute()
        {

        }
    }
}
