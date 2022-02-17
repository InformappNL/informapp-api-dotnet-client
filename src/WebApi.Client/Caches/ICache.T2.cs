
using System.Collections.Generic;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Caches
{
    /// <summary>
    /// Generic interface for caching objects
    /// </summary>
    /// <typeparam name="TKey">The type used as key</typeparam>
    /// <typeparam name="TValue">The type of objects to store</typeparam>
    public interface ICache<TKey, TValue>
    {
        /// <summary>
        /// The cached items
        /// </summary>
        IEnumerable<KeyValuePair<TKey, TValue>> Items { get; }

        /// <summary>
        /// Adds an element with the provided key and value to the <see cref="ICache{TKey, TValue}"/>
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        void Add(TKey key, TValue value);

        /// <summary>
        /// Removes the element with the specified key from the <see cref="ICache{TKey, TValue}"/>
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        void Remove(TKey key);

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">
        /// When this method returns, the value associated with the specified key, if the
        /// key is found; otherwise, the default value for the type of the value parameter.
        /// This parameter is passed uninitialized.</param>
        /// <returns>true if the object that implements <see cref="ICache{TKey, TValue}"/> contains
        /// an element with the specified key; otherwise, false.</returns>
        bool TryGetValue(TKey key, out TValue value);
    }
}
