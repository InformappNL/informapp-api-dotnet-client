using System;

namespace Informapp.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Marks a property as a query parameter
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class QueryParameterAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParameterAttribute"/> class.
        /// </summary>
        public QueryParameterAttribute()
        {

        }
    }
}
