using Informapp.InformSystem.WebApi.Models.Arguments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Informapp.InformSystem.WebApi.Models.DataAnnotations
{
    /// <summary>
    /// Set allowed values
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class AllowedValuesAttribute : ValidationAttribute
    {
        /// <summary>
        /// Type
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Allowed values
        /// </summary>
        public IReadOnlyCollection<object> AllowedValues { get; private set; }

        /// <summary>
        /// Case sensitive
        /// </summary>
        public bool? IgnoreCase { get; private set; }

        /// <summary>
        /// Allowed values in string format
        /// </summary>
        public IReadOnlyCollection<string> StringAllowedValues { get; private set; }

        private Func<object, bool> _isValid;

        private string _errorMessageValues;

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(byte value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(byte[] values) { SetupStruct(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(sbyte value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(sbyte[] values) { SetupStruct(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(short value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(short[] values) { SetupStruct(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(ushort value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(ushort[] values) { SetupStruct(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(int value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(int[] values) { SetupStruct(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(uint value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(uint[] values) { SetupStruct(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(long value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(long[] values) { SetupStruct(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(ulong value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(ulong[] values) { SetupStruct(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(float value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(float[] values) { SetupStruct(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(double value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(double[] values) { SetupStruct(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(char value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(char[] values) { SetupStruct(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(string value, bool ignoreCase = true) { SetupString(new[] { value }, ignoreCase); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(string[] values, bool ignoreCase = true) { SetupString(values, ignoreCase); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(bool value) { SetupStruct(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(bool value1, bool value2) { SetupStruct(new[] { value1, value2 }); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(Type value) { SetupClass(new[] { value }); }
        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(Type[] values) { SetupClass(values); }

        /// <summary>Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.</summary>
        public AllowedValuesAttribute(object[] values) { SetupObject(values); }

        private void SetupClass<T>(IReadOnlyList<T> values)
            where T : class
        {
            var set = Setup(values, EqualityComparer<T>.Default, typeof(T), null);

            _isValid = x =>
            {
                if (x is T value)
                {
                    return set.Contains(value);
                }

                return false;
            };
        }

        private void SetupStruct<T>(IReadOnlyList<T> values)
            where T : struct
        {
            var set = Setup(values, EqualityComparer<T>.Default, typeof(T), null);

            _isValid = x =>
            {
                var value = x as T?;

                if (value.HasValue == true)
                {
                    return set.Contains(value.Value);
                }

                return false;
            };
        }

        private void SetupString(IReadOnlyList<string> values, bool ignoreCase)
        {
            var comparer = ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;

            var set = Setup(values, comparer, typeof(string), ignoreCase);

            _isValid = x =>
            {
                if (x is string value)
                {
                    return set.Contains(value);
                }

                return false;
            };
        }

        private void SetupObject(IReadOnlyList<object> values)
        {
            var type = values
                .Where(x => x != null)
                .Select(x => x.GetType())
                .FirstOrDefault();

            var set = Setup(values, EqualityComparer<object>.Default, type, null);

            bool hasMixedTypes = values
                .Where(x => x.GetType() != type)
                .Any();

            if (hasMixedTypes == true)
            {
                throw new ArgumentException("Can not contain items of different types", nameof(values));
            }

            _isValid = x =>
            {
                return set.Contains(x);
            };
        }

        private ISet<T> Setup<T>(IReadOnlyList<T> values, IEqualityComparer<T> comparer, Type type, bool? ignoreCase)
        {
            Argument.NotNullOrEmpty(values, nameof(values));

            bool containsNull = values
                .Where(x => x == null)
                .Any();

            if (containsNull == true)
            {
                throw new ArgumentException("Can not contain null", nameof(values));
            }

            Type = type;

            var hashSet = new HashSet<T>(values, comparer);

            var allowedValues = new ReadOnlyCollection<T>(hashSet.ToList());

            AllowedValues = allowedValues as IReadOnlyCollection<object>;

            IgnoreCase = ignoreCase;

            var stringAllowedValues = values
                .Select(x => string.Format(CultureInfo.InvariantCulture, "{0}", x))
                .ToList();

            StringAllowedValues = new ReadOnlyCollection<string>(stringAllowedValues);

            _errorMessageValues = string.Join(", ", stringAllowedValues
                .Select(x => string.Format(CultureInfo.InvariantCulture, "'{0}'", x))
                .ToList());

            return hashSet;
        }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            string message = string.Format(
                CultureInfo.InvariantCulture,
                "The field {0} must be one of {1}",
                name,
                _errorMessageValues);

            return message;
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

            bool isValid = _isValid.Invoke(value);

            return isValid;
        }
    }
}
