using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// Specifies that a string or URI field must be an absolute URI.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class MaxUriLengthAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessageFormat = "The {0} field must not be longer than {1} characters.";

        /// <summary>
        /// Length
        /// </summary>
        public int Length { get; }

        /// <summary>Initializes a new instance of the <see cref="MaxUriLengthAttribute"/> class.</summary>
        public MaxUriLengthAttribute(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, "Must be greater than zero");
            }

            Length = length;

            ErrorMessage = DefaultErrorMessageFormat;
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

            if (value is Uri uri)
            {
                if (uri.ToString().Length <= Length)
                {
                    return true;
                }

                return false;
            }

            if (value is string str)
            {
                if (str.Length <= Length)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            string message = string.Format(CultureInfo.InvariantCulture, ErrorMessage, name, Length);

            return message;
        }
    }
}
