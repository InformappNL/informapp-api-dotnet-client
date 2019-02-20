using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.EqualityComparers
{
    /// <summary>
    /// Generic class for default equality comparer
    /// </summary>
    /// <typeparam name="T">The type of objects to compar</typeparam>
    public class DefaultEqualityComparer<T> : IDefaultEqualityComparer<T>
    {
        private static readonly IEqualityComparer<T> _comparer = EqualityComparer<T>.Default;

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public bool Equals(T x, T y)
        {
            return _comparer.Equals(x, y);
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public int GetHashCode(T obj)
        {
            return _comparer.GetHashCode(obj);
        }
    }
}
