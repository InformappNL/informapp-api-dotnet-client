using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.HashCodes;
using System;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.BearerTokenProviders
{
    /// <summary>
    /// Represents a <see cref="BearerTokenKey"/> comparison operation
    /// </summary>
    public class BearerTokenKeyEqualityComparer : IEqualityComparer<BearerTokenKey>
    {
        private const StringComparison Comparison = StringComparison.OrdinalIgnoreCase;

        /// <summary>
        /// Initializes a new instance of the <see cref="BearerTokenKeyEqualityComparer"/> class.
        /// </summary>
        public BearerTokenKeyEqualityComparer()
        {

        }

        /// <summary>
        /// Indicates whether two <see cref="BearerTokenKey"/> instances are equal.
        /// </summary>
        /// <param name="x">A <see cref="BearerTokenKey"/> to compare to <paramref name="y"/></param>
        /// <param name="y">A <see cref="BearerTokenKey"/> to compare to <paramref name="x"/></param>
        /// <returns>true if x and y refer to the same object, or x and y are equal, or x and y are null; otherwise, false.</returns>
        public bool Equals(BearerTokenKey x, BearerTokenKey y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            if (x.EndPoint == y.EndPoint &&
                string.Equals(x.UserName, y.UserName, Comparison) &&
                string.Equals(x.Environment, y.Environment, Comparison) &&
                x.ImpersonateUserId == y.ImpersonateUserId)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the hash code for the specified <see cref="BearerTokenKey"/>.
        /// </summary>
        /// <param name="obj">The <see cref="BearerTokenKey"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/> is null</exception>
        public int GetHashCode(BearerTokenKey obj)
        {
            Argument.NotNull(obj, nameof(obj));

            var stringComparer = StringComparer.OrdinalIgnoreCase;

            int hashCode = HashCodeHelper.DefaultInitialValue;

            hashCode = HashCodeHelper.AddRef(hashCode, obj.EndPoint);
            hashCode = HashCodeHelper.AddString(hashCode, obj.UserName, Comparison);
            hashCode = HashCodeHelper.AddString(hashCode, obj.Environment, Comparison);
            hashCode = HashCodeHelper.AddValue(hashCode, obj.ImpersonateUserId);

            return hashCode;
        }
    }
}
