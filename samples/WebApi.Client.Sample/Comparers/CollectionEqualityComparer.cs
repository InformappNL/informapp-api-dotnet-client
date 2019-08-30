using System;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.Sample.Comparers
{
    internal class CollectionEqualityComparer
    {
        public bool CollectionEquals<T>(IReadOnlyList<T> left, IReadOnlyList<T> right)
            where T : struct, IEquatable<T>
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            if (left.Count != right.Count)
            {
                return false;
            }

            for (int i = 0; i < left.Count; i++)
            {
                if (left[i].Equals(right[i]) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
