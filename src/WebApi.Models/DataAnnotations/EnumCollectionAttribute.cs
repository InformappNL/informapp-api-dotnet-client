using Informapp.InformSystem.WebApi.Models.Arguments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// Enum collection validation attribute class
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class EnumCollectionAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessageFormat = "The {0} field contains undefined values";

        private static readonly MethodInfo _methodInfo = typeof(EnumCollectionAttribute).GetMethod(nameof(GetFunc), BindingFlags.Static | BindingFlags.NonPublic);

        /// <summary>
        /// The enum type
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Allow null values
        /// </summary>
        public bool AllowNull { get; }

        private readonly Func<object, bool> _func;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumCollectionAttribute"/> class.
        /// </summary>
        /// <param name="type">The enum type</param>
        /// <param name="allowNull">allow null values</param>
        internal EnumCollectionAttribute(Type type, bool allowNull = false)
        {
            Argument.NotNull(type, nameof(type));

            if (type.IsEnum == false)
            {
                throw new ArgumentException("The type must be an enum", nameof(type));
            }

            Type = type;

            ErrorMessage = DefaultErrorMessageFormat;

            var method = _methodInfo.MakeGenericMethod(type);

            var func = method.Invoke(null, new object[] { allowNull }) as Func<object, bool>;

            _func = func;
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

            bool valid = _func.Invoke(value);

            return valid;
        }

        private static Func<object, bool> GetFunc<TValue>(bool allowNull)
            where TValue : struct
        {
            var set = new Set<TValue>();

            bool IsValid(object value)
            {
                if (value is IEnumerable<TValue> enumerable)
                {
                    foreach (var item in enumerable)
                    {
                        if (set.Contains(item)) { continue; }

                        return false;
                    }

                    return true;
                }

                if (value is IEnumerable<TValue?> nullable)
                {
                    foreach (var item in nullable)
                    {
                        if (item.HasValue == false)
                        {
                            if (allowNull) { continue; }

                            return false;
                        }

                        if (set.Contains(item.Value)) { continue; }

                        return false;
                    }

                    return true;
                }

                throw new InvalidOperationException(nameof(value) + " is not " + typeof(IEnumerable<TValue>).Name);
            };

            return IsValid;
        }

        private interface ISet<T>
        {
            bool Contains(T key);
        }

        private class Set<T> : ISet<T>
        {
            private static readonly HashSet<T> _hashSet = GetHashSet();

            private static HashSet<T> GetHashSet()
            {
                var values = (T[])Enum.GetValues(typeof(T));

                var hashSet = new HashSet<T>(values);

                return hashSet;
            }

            public bool Contains(T key)
            {
                return _hashSet.Contains(key);
            }
        }
    }
}
