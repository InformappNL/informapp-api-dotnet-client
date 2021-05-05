using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.WebApi.Client.Validators
{
    /// <summary>
    /// Abstraction for <see cref="Validator"/>
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Determines whether the specified object is valid using the validation context and validation results collection.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationContext">The context that describes the object to validate.</param>
        /// <param name="validationResults">A collection to hold each failed validation.</param>
        /// <returns>true if the object validates; otherwise, false.</returns>
        bool TryValidateObject(
            object instance,
            ValidationContext validationContext,
            ICollection<ValidationResult> validationResults);

        /// <summary>
        /// Determines whether the specified object is valid using the validation context,
        /// validation results collection, and a value that specifies whether to validate
        /// all properties.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationContext">The context that describes the object to validate.</param>
        /// <param name="validationResults">A collection to hold each failed validation.</param>
        /// <param name="validateAllProperties">true to validate all properties; if false, only required attributes are validated.</param>
        /// <returns>true if the object validates; otherwise, false.</returns>
        bool TryValidateObject(
            object instance,
            ValidationContext validationContext,
            ICollection<ValidationResult> validationResults,
            bool validateAllProperties);

        /// <summary>
        /// Validates the property.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context that describes the property to validate.</param>
        /// <param name="validationResults">A collection to hold each failed validation.</param>
        /// <returns>true if the property validates; otherwise, false.</returns>
        bool TryValidateProperty(
            object value,
            ValidationContext validationContext,
            ICollection<ValidationResult> validationResults);

        /// <summary>
        /// Returns a value that indicates whether the specified value is valid with the
        /// specified attributes.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context that describes the object to validate.</param>
        /// <param name="validationResults">A collection to hold failed validations.</param>
        /// <param name="validationAttributes">The validation attributes.</param>
        bool TryValidateValue(object value,
            ValidationContext validationContext,
            ICollection<ValidationResult> validationResults,
            IEnumerable<ValidationAttribute> validationAttributes);

        /// <summary>
        /// Determines whether the specified object is valid using the validation context.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationContext">The context that describes the object to validate.</param>
        /// <exception cref="ValidationException">The object is not valid.</exception>
        void ValidateObject(
            object instance,
            ValidationContext validationContext);

        /// <summary>
        /// Determines whether the specified object is valid using the validation context,
        /// and a value that specifies whether to validate all properties.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="validationContext">The context that describes the object to validate.</param>
        /// <param name="validateAllProperties">true to validate all properties; otherwise, false.</param>
        /// <exception cref="ValidationException">The object is not valid.</exception>
        void ValidateObject(
            object instance,
            ValidationContext validationContext,
            bool validateAllProperties);

        /// <summary>
        /// Validates the property.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context that describes the property to validate.</param>
        /// <exception cref="ValidationException">The value parameter is not valid.</exception>
        void ValidateProperty(
            object value,
            ValidationContext validationContext);

        /// <summary>
        /// Validates the specified attributes.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context that describes the object to validate.</param>
        /// <param name="validationAttributes">The validation attributes.</param>
        /// <exception cref="ValidationException">The value parameter does not validate with the <paramref name="validationAttributes"/> parameter.</exception>
        void ValidateValue(
            object value,
            ValidationContext validationContext,
            IEnumerable<ValidationAttribute> validationAttributes);
    }
}
