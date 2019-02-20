using System;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// Specifies that a string or URI field must be a relative URI.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class RelativeUriAttribute : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelativeUriAttribute"/> class.
        /// </summary>
        internal RelativeUriAttribute()
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

            if (value is Uri uri && uri.IsAbsoluteUri == false)
            {
                return true;
            }

            if (value is string str && Uri.TryCreate(str, UriKind.Relative, out uri))
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
            return "The field " + name + " must be a relative URI";
        }
    }
}
