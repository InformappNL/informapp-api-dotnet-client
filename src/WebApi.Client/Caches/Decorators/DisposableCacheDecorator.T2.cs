﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Caches.Decorators
{
    /// <summary>
    /// Decorator for <see cref="ICache{TKey, TValue}"/> to dispose of cached items implementing <see cref="IDisposable"/>
    /// </summary>
    /// <typeparam name="TKey">The type used as key</typeparam>
    /// <typeparam name="TValue">The type of objects to store</typeparam>
    public class DisposableCacheDecorator<TKey, TValue> : Decorator<ICache<TKey, TValue>>,
        ICache<TKey, TValue>,
        IDisposable
    {
        private readonly ICache<TKey, TValue> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableCacheDecorator{Tkey, TValue}"/> class.
        /// </summary>
        /// <param name="cache">The instance to decorate</param>
        public DisposableCacheDecorator(
            ICache<TKey, TValue> cache) : base(cache)
        {
            Argument.NotNull(cache, nameof(cache));

            _cache = cache;
        }

        /// <summary>
        /// The cached items
        /// </summary>
        public IEnumerable<KeyValuePair<TKey, TValue>> Items => _cache.Items;

        /// <summary>
        /// Adds an element with the provided key and value to the <see cref="ICache{TKey, TValue}"/>
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        public void Add(TKey key, TValue value)
        {
            _cache.Add(key, value);
        }

        /// <summary>
        /// Removes the element with the specified key from the <see cref="ICache{TKey, TValue}"/>
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        public void Remove(TKey key)
        {
            if (_cache.TryGetValue(key, out var value) == true)
            {
                _cache.Remove(key);

                if (value is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            else
            {
                _cache.Remove(key);
            }
        }

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
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _cache.TryGetValue(key, out value);
        }

        #region IDisposable

        private bool _isDisposed;

        /// <summary>
        /// Releases the unmanaged resources used and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed == false)
            {
                if (disposing)
                {
                    // Dispose of cached items implementing
                    var items = _cache.Items
                        .Select(x => x.Value)
                        .OfType<IDisposable>()
                        .ToList();

                    foreach (var item in items)
                    {
                        item.Dispose();
                    }
                }

                _isDisposed = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
