using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// File name validation attribute class
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public sealed class FileNameLengthAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets the maximum length of a file name.
        /// </summary>
        public int MaximumLength { get; }

        /// <summary>
        /// Gets the minimum length of a file name.
        /// </summary>
        public int MinimumLength { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileNameLengthAttribute"/> class.
        /// </summary>
        /// <param name="maximumLength">The maximum length of a file name</param>
        public FileNameLengthAttribute(int maximumLength) : this(0, maximumLength)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileNameLengthAttribute"/> class.
        /// </summary>
        /// <param name="minimumLength">The minimum length of a string</param>
        /// <param name="maximumLength">The maximum length of a string</param>
        public FileNameLengthAttribute(int minimumLength, int maximumLength)
        {
            if (minimumLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minimumLength), minimumLength, "Must not be smaller than zero.");
            }

            if (maximumLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maximumLength), maximumLength, "Must not be smaller than zero.");
            }

            if (maximumLength < minimumLength)
            {
                throw new ArgumentException("Must be greater than " + nameof(minimumLength), nameof(maximumLength));
            }

            MinimumLength = minimumLength;

            MaximumLength = maximumLength;
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

            if (value is string stringValue)
            {
                // Handled by RequiredAttribute
                if (string.IsNullOrEmpty(stringValue) == true)
                {
                    return true;
                }

                if (stringValue.Length > MaximumLength)
                {
                    return false;
                }

                if (stringValue.Length < MinimumLength)
                {
                    return false;
                }

                return true;
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

            if (MinimumLength > 0)
            {
                message = string.Format(
                    CultureInfo.InvariantCulture,
                    "The file name must be between {1} and {2} characters in length",
                    MinimumLength, MaximumLength);
            }
            else
            {
                message = string.Format(
                    CultureInfo.InvariantCulture,
                    "The file name must not exceed {0} characters in length",
                    MaximumLength);
            }

            return message;
        }
    }
}
