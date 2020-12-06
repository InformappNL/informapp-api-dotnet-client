using System;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// Specifies that a string or URI field must be an absolute URI.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class AbsoluteUriAttribute : ValidationAttribute
    {
        /// <summary>Initializes a new instance of the <see cref="AbsoluteUriAttribute"/> class.</summary>
        public AbsoluteUriAttribute()
        {

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

            if (value is Uri uri && uri.IsAbsoluteUri == true)
            {
                return true;
            }

            if (value is string str && Uri.TryCreate(str, UriKind.Absolute, out _))
            {
                return true;
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
            return "The field " + name + " must be an absolute URI";
        }
    }
}
