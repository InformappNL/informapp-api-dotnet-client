using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;

namespace Informapp.InformSystem.WebApi.Client.Requests
{
    /// <summary>
    /// Api credentials
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ", nq}")]
    public class ApiCredentials : IValidatableObject
    {
        /// <summary>
        /// The username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Returns true when a password is set, null otherwise
        /// </summary>
        [Required]
        public bool? HasPassword => string.IsNullOrEmpty(Password) == false ? true : default(bool?);

        /// <summary>
        /// The password
        /// </summary>
        public string Password { private get; set; }

        /// <summary>
        /// Get password
        /// </summary>
        /// <returns>The password</returns>
#pragma warning disable CA1024 // Use properties where appropriate
        public string GetPassword()
#pragma warning restore CA1024 // Use properties where appropriate
        {
            return Password;
        }

        /// <summary>
        /// The environment
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Impersonate user id
        /// </summary>
        public Guid? ImpersonateUserId { get; set; }

        /// <summary>
        /// Kind
        /// </summary>
        public CredentialsKind Kind { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "Credentials: {0} = {1}, {2} = {3}",
            nameof(Username), Username,
            nameof(HasPassword), HasPassword);

        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A collection that holds failed-validation information.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var required = new RequiredAttribute();

            switch (Kind)
            {
                case CredentialsKind.Default:
                    break;
                case CredentialsKind.Environment:
                    if (string.IsNullOrEmpty(Environment) == true)
                    {
                        yield return new ValidationResult(required.FormatErrorMessage(nameof(Environment)));
                    }
                    break;
                case CredentialsKind.Impersonate:
                    if (string.IsNullOrEmpty(Environment) == true)
                    {
                        yield return new ValidationResult(required.FormatErrorMessage(nameof(Environment)));
                    }
                    if (ImpersonateUserId.HasValue == false)
                    {
                        yield return new ValidationResult(required.FormatErrorMessage(nameof(ImpersonateUserId)));
                    }
                    break;
                default:
                    throw new InvalidOperationException("Unsupported value: " + Kind);
            }
        }
    }
}
