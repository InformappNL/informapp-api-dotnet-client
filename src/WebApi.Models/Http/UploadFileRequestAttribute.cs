using ConnectedDevelopment.InformSystem.WebApi.Models.Arguments;
using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Indicates a file upload request
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class UploadFileRequestAttribute : Attribute
    {
        /// <summary>
        /// The file parameter name
        /// </summary>
        public string FileParameterName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileRequestAttribute"/> class.
        /// </summary>
        public UploadFileRequestAttribute(string fileParameterName)
        {
            Argument.NotNullOrEmpty(fileParameterName, nameof(fileParameterName));

            FileParameterName = fileParameterName;
        }
    }
}
