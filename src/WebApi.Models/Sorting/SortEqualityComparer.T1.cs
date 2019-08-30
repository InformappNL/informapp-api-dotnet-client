using System;
using System.Collections.Generic;
using System.Linq;

namespace Informapp.InformSystem.WebApi.Models.Sorting
{
    /// <summary>
    /// Compare equality for sort enum members
    /// </summary>
    /// <typeparam name="T">Enum type to compare</typeparam>
    internal class SortEqualityComparer<T> : IEqualityComparer<T>
        where T : struct, Enum, IComparable, IFormattable, IConvertible
    {
        private static readonly IDictionary<T, string> _dictionary = GetDictionary();

        private static IDictionary<T, string> GetDictionary()
        {
            if (typeof(T).IsEnum == false)
            {
                throw new InvalidOperationException("Type parameter " + nameof(T) + "must be an " + nameof(Enum));
            }

            var values = ((T[])Enum.GetValues(typeof(T)))
                .Select(x => new
                {
                    Value = x,
                    Attribute = (SortNameAttribute)typeof(T)
                        .GetMember(x.ToString())
                        .First()
                        .GetCustomAttributes(typeof(SortNameAttribute), inherit: false)
                        .SingleOrDefault()
                })
                .ToList();

            var faultyValues = values
                .Where(x => x.Attribute == null)
                .ToList();

            if (faultyValues.Any() == true)
            {
                throw new InvalidOperationException(typeof(T).Name + " has members without " + nameof(SortNameAttribute));
            }

            return values
                .ToDictionary(x => x.Value, x => x.Attribute.Name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortEqualityComparer{T}"/> class.
        /// </summary>
        public SortEqualityComparer()
        {

        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type <typeparamref name="T"/> to compare.</param>
        /// <param name="y">The second object of type <typeparamref name="T"/> to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public bool Equals(T x, T y)
        {
            if (_dictionary.TryGetValue(x, out string left) &&
                _dictionary.TryGetValue(y, out string right))
            {
                return StringComparer.Ordinal.Equals(left, right);
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The object of <typeparamref name="T"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public int GetHashCode(T obj)
        {
            if (_dictionary.TryGetValue(obj, out string value))
            {
                return value.GetHashCode();
            }

            return obj.GetHashCode();
        }
    }
}
