using System;

namespace Informapp.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Indicates a file download request
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class DownloadFileRequestAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadFileRequestAttribute"/> class.
        /// </summary>
        public DownloadFileRequestAttribute()
        {

        }
    }
}
