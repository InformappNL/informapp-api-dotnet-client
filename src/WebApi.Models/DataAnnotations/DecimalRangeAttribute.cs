using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// Specifies that a string or URI field must be an absolute URI.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class DecimalRangeAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets the maximum allowed field value.
        /// </summary>
        /// <returns>
        /// The maximum value that is allowed for the data field.
        /// </returns>
        public decimal Maximum { get; }

        /// <summary>
        /// Gets the minimum allowed field value.
        /// </summary>
        /// <returns>
        /// The minimum value that is allowed for the data field.
        /// </returns>
        public decimal Minimum { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbsoluteUriAttribute"/> class.
        /// </summary>
        /// <param name="minimum">
        /// Specifies the minimum value allowed for the data field value.
        /// </param>
        /// <param name="maximum">
        /// Specifies the maximum value allowed for the data field value.
        /// </param>
#pragma warning disable CA1019 // Define accessors for attribute arguments
        public DecimalRangeAttribute(string minimum, string maximum)
#pragma warning restore CA1019 // Define accessors for attribute arguments
        {
            if (decimal.TryParse(minimum, out decimal decimalMinimum) == false)
            {
                throw new ArgumentException("Unable to parse value", nameof(minimum));
            }

            if (decimal.TryParse(maximum, out decimal decimalMaximum) == false)
            {
                throw new ArgumentException("Unable to parse value", nameof(maximum));
            }

            if (decimalMinimum > decimalMaximum)
            {
                const string message = "Must be less than the value in " + nameof(maximum);

                throw new ArgumentException(message, nameof(minimum));
            }

            Minimum = decimalMinimum;

            Maximum = decimalMaximum;
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

            if (value is decimal decimalValue)
            {
                if (decimalValue >= Minimum && decimalValue <= Maximum)
                {
                    return true;
                }
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
            string message = string.Format(
                CultureInfo.CurrentCulture,
                "The field {0} must be between {1} and {2}",
                name,
                Minimum,
                Maximum);

            return message;
        }
    }
}
