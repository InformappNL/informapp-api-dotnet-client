using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Indicates a file upload response
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class UploadFileResponseAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileResponseAttribute"/> class.
        /// </summary>
        public UploadFileResponseAttribute()
        {

        }
    }
}
