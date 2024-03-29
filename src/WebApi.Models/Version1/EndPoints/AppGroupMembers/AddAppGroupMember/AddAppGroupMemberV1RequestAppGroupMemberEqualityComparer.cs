﻿using System;
using System.Collections.Generic;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.AddAppGroupMember
{
    /// <summary>
    /// Represents a <see cref="AddAppGroupMemberV1RequestAppGroupMember"/> comparison operation
    /// </summary>
    internal class AddAppGroupMemberV1RequestAppGroupMemberEqualityComparer : IEqualityComparer<AddAppGroupMemberV1RequestAppGroupMember>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddAppGroupMemberV1RequestAppGroupMemberEqualityComparer"/> class.
        /// </summary>
        public AddAppGroupMemberV1RequestAppGroupMemberEqualityComparer()
        {

        }

        /// <summary>
        /// Indicates whether two <see cref="AddAppGroupMemberV1RequestAppGroupMember"/> instances are equal.
        /// </summary>
        /// <param name="x">A <see cref="AddAppGroupMemberV1RequestAppGroupMember"/> to compare to <paramref name="y"/></param>
        /// <param name="y">A <see cref="AddAppGroupMemberV1RequestAppGroupMember"/> to compare to <paramref name="x"/></param>
        /// <returns>true if x and y refer to the same object, or x and y are equal, or x and y are null; otherwise, false.</returns>
        public bool Equals(AddAppGroupMemberV1RequestAppGroupMember x, AddAppGroupMemberV1RequestAppGroupMember y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return x == null && y == null;
            }

            if (x.AppGroupId == y.AppGroupId &&
                x.AppUserId == y.AppUserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the hash code for the specified <see cref="AddAppGroupMemberV1RequestAppGroupMember"/>.
        /// </summary>
        /// <param name="obj">The <see cref="AddAppGroupMemberV1RequestAppGroupMember"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/> is null</exception>
        public int GetHashCode(AddAppGroupMemberV1RequestAppGroupMember obj)
        {
            if (obj != null)
            {
                unchecked
                {
                    int hash = 17;

                    if (obj.AppGroupId.HasValue == true)
                    {
                        hash = (hash * 23) + obj.AppGroupId.GetHashCode();
                    }

                    if (obj.AppUserId.HasValue == true)
                    {
                        hash = (hash * 23) + obj.AppUserId.GetHashCode();
                    }

                    return hash;
                }
            }

            return 0;
        }
    }
}
