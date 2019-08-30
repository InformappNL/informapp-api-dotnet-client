using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.Http
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
        internal UploadFileRequestAttribute(string fileParameterName)
        {
            if (string.IsNullOrEmpty(fileParameterName) == true)
            {
                if (fileParameterName == null)
                {
                    throw new ArgumentNullException(nameof(fileParameterName));
                }

                throw new ArgumentException("Must not be empty", nameof(fileParameterName));
            }

            FileParameterName = fileParameterName;
        }
    }
}
