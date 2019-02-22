using Informapp.InformSystem.WebApi.Client.Arguments;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.Caches
{
    /// <summary>
    /// Generic class to cache objects using <see cref="IDictionary{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TKey">The type used as key</typeparam>
    /// <typeparam name="TValue">The type of objects to store</typeparam>
    public class DictionaryCache<TKey, TValue> : ICache<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> _dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryCache{Tkey, TValue}"/> class.
        /// </summary>
        public DictionaryCache(
            IDictionary<TKey, TValue> dictionary)
        {
            Argument.NotNull(dictionary, nameof(dictionary));

            _dictionary = dictionary;
        }

        /// <summary>
        /// The cached items
        /// </summary>
        public IEnumerable<KeyValuePair<TKey, TValue>> Items { get { return _dictionary; } }

        /// <summary>
        /// Adds an element with the provided key and value to the cache"/>
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        public void Add(TKey key, TValue value)
        {
            Argument.Required(key, nameof(key));
            Argument.Required(value, nameof(value));

            _dictionary[key] = value;
        }

        /// <summary>
        /// Removes the element with the specified key from the cache"/>
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        public void Remove(TKey key)
        {
            Argument.Required(key, nameof(key));

            _dictionary.Remove(key);
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
            Argument.Required(key, nameof(key));

            return _dictionary.TryGetValue(key, out value);
        }
    }
}
