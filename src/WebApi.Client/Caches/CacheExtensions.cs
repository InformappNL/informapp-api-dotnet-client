using Informapp.InformSystem.WebApi.Client.Arguments;
using System;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Caches
{
    /// <summary>
    /// Extensions for <see cref="ICache{TKey, TValue}"/>
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// Get value from cache, create and add if it does not exist
        /// </summary>
        /// <typeparam name="TKey">The type of key</typeparam>
        /// <typeparam name="TValue">The type of value</typeparam>
        /// <param name="cache"></param>
        /// <param name="key">The key</param>
        /// <param name="creator">The delegate to create the value</param>
        /// <returns>The value</returns>
        public static TValue GetOrAdd<TKey, TValue>(
            this ICache<TKey, TValue> cache, TKey key, Func<TValue> creator)
        {
            Argument.NotNull(cache, nameof(cache));
            Argument.NotNull(creator, nameof(creator));

            if (cache.TryGetValue(key, out var value) == false)
            {
                value = creator.Invoke();

                cache.Add(key, value);
            }

            return value;
        }

        /// <summary>
        /// Get value from cache, create and add if it does not exist
        /// </summary>
        /// <typeparam name="TKey">The type of key</typeparam>
        /// <typeparam name="TValue">The type of value</typeparam>
        /// <param name="cache"></param>
        /// <param name="key">The key</param>
        /// <param name="creator">The delegate to create the value</param>
        /// <returns>The value</returns>
        public static async Task<TValue> GetOrAddAsync<TKey, TValue>(
            this ICache<TKey, TValue> cache, TKey key, Func<Task<TValue>> creator)
        {
            Argument.NotNull(cache, nameof(cache));
            Argument.NotNull(creator, nameof(creator));

            if (cache.TryGetValue(key, out var value) == false)
            {
                value = await creator
                    .Invoke()
                    .ConfigureAwait(Await.Default);

                cache.Add(key, value);
            }

            return value;
        }
    }
}
