using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// Specifies the minimum number of items in an <see cref="IEnumerable"/> allowed in a property or field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class MinItemsAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessageFormat = "The {0} field must not contain fewer than {1} items.";

        /// <summary>
        /// Count
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinItemsAttribute"/> class.
        /// </summary>
        /// <param name="count"></param>
        internal MinItemsAttribute(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Must be greater or equal to zero");
            }

            Count = count;

            ErrorMessage = DefaultErrorMessageFormat;
        }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            string message = string.Format(CultureInfo.InvariantCulture, ErrorMessage, name, Count);

            return message;
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

            else if (value is Array array)
            {
                if (array.Length >= Count) { return true; }
            }

            else if (value is ICollection collection)
            {
                if (collection.Count >= Count) { return true; }
            }

            else if (value is IDictionary dictionary)
            {
                if (dictionary.Count >= Count) { return true; }
            }

            else if (value is IEnumerable enumerable)
            {
                int count = enumerable
                    .OfType<object>()
                    .Count();

                if (count >= Count) { return true; }
            }

            else
            {
                throw new InvalidOperationException("Unable to convert value to " + nameof(IEnumerable));
            }

            return false;
        }
    }
}
