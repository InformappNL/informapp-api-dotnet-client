using Informapp.InformSystem.WebApi.Models.Arguments;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// Specifies that a string field must be in valid Json format.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class JsonDeserializeAttribute : ValidationAttribute
    {
        /// <summary>
        /// Type of object that will be validated
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Type description of object that will be validated
        /// </summary>
        public string TypeDescription { get; }

        /// <summary>Initializes a new instance of the <see cref="JsonDeserializeAttribute"/> class.</summary>
        public JsonDeserializeAttribute(
            Type type,
            string typeDescription)
        {
            Argument.NotNull(type, nameof(type));
            Argument.NotNullOrEmpty(typeDescription, nameof(typeDescription));

            Type = type;

            TypeDescription = typeDescription;
        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            if (value is string stringValue)
            {
                if (TryParseJson(stringValue, Type))
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
            return "The field " + name + " must be in valid Json format to deserialize to " + TypeDescription;
        }

        private static bool TryParseJson(string value, Type type)
        {
            bool success = true;
            var settings = new JsonSerializerSettings
            {
                Error = (sender, args) => { success = false; args.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error
            };

            var result = JsonConvert.DeserializeObject(value, type, settings);

            return success;
        }
    }
}

