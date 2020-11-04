using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// Specifies values in a property or field must be a multiple of a given number
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class MultipleOfAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessageFormat = "The {0} field is not a multiple of {1}";

        /// <summary>
        /// Value
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleOfAttribute"/> class.
        /// </summary>
        public MultipleOfAttribute(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "Must be greater than 0");
            }

            Value = value;

            ErrorMessage = DefaultErrorMessageFormat;
        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            if (value is null)
            {
                return true;
            }

            if (value is sbyte numbersByte)
            {
                return (numbersByte % Value == 0);
            }

            if (value is byte numberByte)
            {
                return (numberByte % Value == 0);
            }

            if (value is short numberInt16)
            {
                return (numberInt16 % Value == 0);
            }

            if (value is ushort numberUInt16)
            {
                return (numberUInt16 % Value == 0);
            }

            if (value is int numberInt)
            {
                return (numberInt % Value == 0);
            }

            if (value is uint numberUInt)
            {
                return (numberUInt % Value == 0);
            }

            if (value is long numberLong)
            {
                return (numberLong % Value == 0);
            }

            if (value is ulong numberULong)
            {
                return (numberULong % (ulong)Value == 0);
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
                ErrorMessage, 
                name, 
                Value);

            return message;
        }
    }
}
