﻿using ConnectedDevelopment.InformSystem.WebApi.Models.Arguments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations
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
        public IEnumerable<string> Extensions => new ReadOnlyCollection<string>(_extensions);

        /// <summary>
        /// Initializes a new instance of the <see cref="FileNameLengthAttribute"/> class.
        /// </summary>
        /// <param name="extensions">The allowed file extensions, separated by space</param>
#pragma warning disable CA1019 // Define accessors for attribute arguments
        public FileTypeAttribute(string extensions)
#pragma warning restore CA1019 // Define accessors for attribute arguments
        {
            Argument.NotNullOrEmpty(extensions, nameof(extensions));

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
                if (fileName.Length == 0)
                {
                    return true;
                }
                else
                {
                    string extension = Path.GetExtension(fileName);

                    // No extension
                    if (string.IsNullOrEmpty(extension) == true ||
                        extension.Length == 1)
                    {
                        return false;
                    }

                    extension = extension.Substring(1);

                    return _extensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
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

                message = string.Format(
                    CultureInfo.InvariantCulture,
                    "The file extension must be one of '{0}'",
                    formattedExtensions);
            }
            else
            {
                message = string.Format(
                    CultureInfo.InvariantCulture,
                    "The file extension must be {0}",
                    _extensions[0]);
            }

            return message;
        }
    }
}
