using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations
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
        public FileSizeAttribute(long size)
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
                    throw new ArgumentException("The stream must support seek operations.", nameof(value));
                }

                return stream.Length <= Size;
            }
            if (value is long longValue)
            {
                return longValue <= Size;
            }
            else
            {
                throw new ArgumentException("The object to validate is not a Stream or Int64.", nameof(value));
            }
        }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            string message = string.Format(
                CultureInfo.InvariantCulture,
                "The file size must not exceed {0} bytes",
                Size);

            return message;
        }
    }
}
