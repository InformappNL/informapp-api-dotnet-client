using Informapp.InformSystem.WebApi.Models.Arguments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// Enum validation attribute class
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class EnumValidationAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessageFormat = "The {0} field is not a defined value";

        private static readonly MethodInfo _methodInfo = typeof(EnumValidationAttribute).GetMethod(nameof(GetSet), BindingFlags.Static | BindingFlags.NonPublic);

        /// <summary>
        /// The enum type
        /// </summary>
        public Type Type { get; }

        private readonly ISet _set;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumValidationAttribute"/> class.
        /// </summary>
        /// <param name="type">The enum type</param>
        internal EnumValidationAttribute(Type type)
        {
            Argument.NotNull(type, nameof(type));

            if (type.IsEnum == false)
            {
                throw new ArgumentException("The type must be an enum", nameof(type));
            }

            Type = type;

            var method = _methodInfo.MakeGenericMethod(type);

            var set = method.Invoke(null, null) as ISet;

            _set = set;

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

            return _set.Contains(value);
        }

        private static ISet GetSet<T>()
        {
            return new Set<T>();
        }

        private interface ISet
        {
            bool Contains(object key);
        }

        private class Set<T> : ISet
        {
            private static readonly HashSet<T> _hashSet = GetHashSet();

            private static HashSet<T> GetHashSet()
            {
                var values = (T[])Enum.GetValues(typeof(T));

                var hashSet = new HashSet<T>(values);

                return hashSet;
            }

            public bool Contains(object key)
            {
                if (key is T strongKey)
                {
                    return _hashSet.Contains(strongKey);
                }

                return false;
            }
        }
    }
}
