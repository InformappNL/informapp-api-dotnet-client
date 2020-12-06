using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// Require unique items on <see cref="IEnumerable{T}"/> properties and fields
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class UniqueItemsAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessageFormat = "The {0} field contains duplicate values";

        /// <summary>
        /// Ignore case
        /// </summary>
        public bool? IgnoreCase { get; }



        private UniqueItemsAttribute()
        {
            ErrorMessage = DefaultErrorMessageFormat;
        }



        private UniqueItemsAttribute(Type value, bool? ignoreCase) : this()
        {
            var method = typeof(UniqueItemsAttribute)
                .GetMethod(nameof(SetupWithDefaultComparer), BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(value);

            method.Invoke(this, null);

            IgnoreCase = ignoreCase;
        }

        /// <summary>Initializes a new instance of the <see cref="UniqueItemsAttribute"/> class.</summary>
        public UniqueItemsAttribute(Type value) : this(value, default(bool?)) { }
        /// <summary>Initializes a new instance of the <see cref="UniqueItemsAttribute"/> class.</summary>
        public UniqueItemsAttribute(Type value, bool ignoreCase) : this(value, (bool?)ignoreCase) { }



        private UniqueItemsAttribute(Type value, Type comparer, bool? ignoreCase) : this()
        {
            var method = typeof(UniqueItemsAttribute)
                .GetMethod(nameof(SetupWithComparer), BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(value, comparer);

            method.Invoke(this, null);

            IgnoreCase = ignoreCase;
        }

        /// <summary>Initializes a new instance of the <see cref="UniqueItemsAttribute"/> class.</summary>
        public UniqueItemsAttribute(Type value, Type comparer) : this(value, comparer, default(bool?)) { }
        /// <summary>Initializes a new instance of the <see cref="UniqueItemsAttribute"/> class.</summary>
        public UniqueItemsAttribute(Type value, Type comparer, bool ignoreCase) : this(value, comparer, (bool?)ignoreCase) { }



        /// <summary>Initializes a new instance of the <see cref="UniqueItemsAttribute"/> class.</summary>
        public UniqueItemsAttribute(StringComparison comparison) : this()
        {
            IEqualityComparer<string> comparer;

            bool ignoreCase;

            switch (comparison)
            {
                case StringComparison.CurrentCulture:
                    comparer = StringComparer.CurrentCulture;
                    ignoreCase = false;
                    break;
                case StringComparison.CurrentCultureIgnoreCase:
                    comparer = StringComparer.CurrentCultureIgnoreCase;
                    ignoreCase = true;
                    break;
                case StringComparison.InvariantCulture:
                    comparer = StringComparer.InvariantCulture;
                    ignoreCase = false;
                    break;
                case StringComparison.InvariantCultureIgnoreCase:
                    comparer = StringComparer.InvariantCultureIgnoreCase;
                    ignoreCase = true;
                    break;
                case StringComparison.Ordinal:
                    comparer = StringComparer.Ordinal;
                    ignoreCase = false;
                    break;
                case StringComparison.OrdinalIgnoreCase:
                    comparer = StringComparer.OrdinalIgnoreCase;
                    ignoreCase = true;
                    break;
                default:
                    throw new ArgumentException("Unsupported comparison: " + comparison, nameof(comparison));
            }

            IgnoreCase = ignoreCase;

            var method = typeof(UniqueItemsAttribute)
                .GetMethod(nameof(Setup), BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(typeof(string), typeof(IEqualityComparer<string>));

            method.Invoke(this, new[] { comparer });
        }

        private Func<object, bool> _isValid;

        private void SetupWithComparer<TValue, TComparer>()
            where TComparer : class, IEqualityComparer<TValue>, new()
        {
            var comparer = new TComparer();

            Setup<TValue, TComparer>(comparer);
        }

        private void SetupWithDefaultComparer<TValue>()
        {
            var comparer = EqualityComparer<TValue>.Default;

            Setup<TValue, IEqualityComparer<TValue>>(comparer);
        }

        private void Setup<TValue, TComparer>(TComparer comparer)
            where TComparer : class, IEqualityComparer<TValue>
        {
            bool IsValid(object value)
            {
                if (value is IEnumerable<TValue> collection)
                {
                    var hashSet = new HashSet<TValue>(comparer);

                    foreach (var item in collection)
                    {
                        if (hashSet.Add(item))
                        {
                            continue;
                        }

                        return false;
                    }

                    return true;
                }

                throw new InvalidOperationException(nameof(value) + " is not " + typeof(IEnumerable<TValue>).Name);
            }

            _isValid = IsValid;
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

            bool valid = _isValid.Invoke(value);

            return valid;
        }
    }
}
