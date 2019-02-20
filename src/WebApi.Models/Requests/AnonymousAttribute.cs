using System;

namespace Informapp.InformSystem.WebApi.Models.Requests
{
    /// <summary>
    /// Specify a request can be done anonymously
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class AnonymousAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousAttribute"/> class.
        /// </summary>
        internal AnonymousAttribute()
        {
            
        }
    }
}
