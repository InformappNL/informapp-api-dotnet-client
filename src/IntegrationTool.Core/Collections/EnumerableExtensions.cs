using System.Collections.Generic;

namespace Informapp.InformSystem.IntegrationTool.Core.Collections
{
    internal static class EnumerableExtensions
    {
        // Needed for Net Standard 2.0
        public static HashSet<TSource> ToHashSet<TSource>(
            this IEnumerable<TSource> source)
        {
            return new HashSet<TSource>(source);
        }

        public static HashSet<TSource> ToHashSet<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            return new HashSet<TSource>(source, comparer);
        }
    }
}
