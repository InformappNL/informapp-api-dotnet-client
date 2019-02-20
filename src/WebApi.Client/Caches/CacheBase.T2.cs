﻿using Informapp.InformSystem.WebApi.Client.Arguments;

namespace Informapp.InformSystem.WebApi.Client.Caches
{
    /// <summary>
    /// Cache base
    /// </summary>
    /// <typeparam name="TKey">The type used as key</typeparam>
    /// <typeparam name="TValue">The type of objects to store</typeparam>
    public abstract class CacheBase<TKey, TValue> : ICache<TKey, TValue>
    {
        private readonly ICache<TKey, TValue> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheBase{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="cache">The cache instance to use</param>
        protected CacheBase(
            ICache<TKey, TValue> cache)
        {
            Argument.NotNull(cache, nameof(cache));

            _cache = cache;
        }

        /// <summary>
        /// Adds an element with the provided key and value to the cache"/>
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        public void Add(TKey key, TValue value)
        {
            _cache.Add(key, value);
        }

        /// <summary>
        /// Removes the element with the specified key from the cache"/>
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        public void Remove(TKey key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">
        /// When this method returns, the value associated with the specified key, if the
        /// key is found; otherwise, the default value for the type of the value parameter.
        /// This parameter is passed uninitialized.</param>
        /// <returns>true if the cache contains an element with the specified key; otherwise, false.</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _cache.TryGetValue(key, out value);
        }
    }
}
