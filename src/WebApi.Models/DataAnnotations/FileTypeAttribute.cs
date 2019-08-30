using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// File type validation attribute class
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class FileTypeAttribute : ValidationAttribute
    {
        private readonly IList<string> _extensions;

        /// <summary>
        /// The allowed file extensions
        /// </summary>
        public IEnumerable<string> Extensions { get { return new ReadOnlyCollection<string>(_extensions); } }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileNameLengthAttribute"/> class.
        /// </summary>
        /// <param name="extensions">The allowed file extensions, separated by space</param>
        internal FileTypeAttribute(string extensions)
        {
            if (string.IsNullOrEmpty(extensions) == true)
            {
                if (extensions == null)
                {
                    throw new ArgumentNullException(nameof(extensions));
                }

                throw new ArgumentException("Must not be empty", nameof(extensions));
            }

            _extensions = extensions.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            // Handled by RequiredAttribute
            if (value == null)
            {
                return true;
            }

            if (value is string fileName)
            {
                // Handled by RequiredAttribute
                if (string.IsNullOrEmpty(fileName) == true)
                {
                    return true;
                }
                else
                {
                    var fileExtension = Path.GetExtension(fileName);

                    // No extension
                    if (string.IsNullOrEmpty(fileExtension) == true)
                    {
                        return false;
                    }

                    foreach (var extension in _extensions)
                    {
                        if (fileName.EndsWith(extension) == true)
                        {
                            return true;
                        }
                    }

                    // Extension not allowed
                    return false;
                }
            }
            else
            {
                throw new InvalidOperationException("The object to validate is not a " + nameof(String));
            }
        }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            string message;

            if (_extensions.Count > 1)
            {
                string formattedExtensions = string.Join(", ", _extensions);

                message = string.Format("The file extension must be one of '{1}'", 
                    name, formattedExtensions);
            }
            else
            {
                message = string.Format("The file extension must be {1}", 
                    name, _extensions[0]);
            }

            return message;
        }
    }
}
