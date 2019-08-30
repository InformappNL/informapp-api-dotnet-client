using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// File size validation attribute class
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class FileSizeAttribute : ValidationAttribute
    {
        /// <summary>
        /// Size
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSizeAttribute"/> class.
        /// </summary>
        /// <param name="size"></param>
        internal FileSizeAttribute(long size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Must be greater than zero.");
            }

            Size = size;
        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is Stream stream)
            {
                if (stream.CanSeek == false)
                {
                    throw new InvalidOperationException("The stream must support seek operations.");
                }

                if (stream.Length > Size)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new InvalidOperationException("The object to validate is not a " + nameof(Stream));
            }
        }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            string message = string.Format("The file size must not exceed {1} bytes", 
                name, Size);

            return message;
        }
    }
}
