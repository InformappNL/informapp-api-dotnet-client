using System;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.Sample.Comparers
{
    internal class DictionaryEqualityComparer
    {
        public bool DictionaryEquals<T>(IReadOnlyDictionary<T, T> left, IReadOnlyDictionary<T, T> right)
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

            foreach (var pair in left)
            {
                if (right.TryGetValue(pair.Key, out var value) == false)
                {
                    return false;
                }

                if (pair.Value.Equals(value) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
