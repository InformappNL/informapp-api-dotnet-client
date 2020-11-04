using Informapp.InformSystem.WebApi.Client.Arguments;
using System;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.Disposables
{
    /// <summary>
    /// Represents a collection of <see cref="IDisposable"/> resources
    /// </summary>
    public class DisposableResources : IDisposableResources,
        IDisposable
    {
        private const int Capacity = 4;

        private readonly IList<IDisposable> _resources;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableResources"/> class.
        /// </summary>
        public DisposableResources()
        {
            _resources = new List<IDisposable>(Capacity);
        }

        /// <summary>
        /// Indicates whether this object has been disposed
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Register the <see cref="IDisposable"/> resource for disposal
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <exception cref="ObjectDisposedException">This instance has been disposed</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="resource"/> is null</exception>
        public void RegisterForDisposal(IDisposable resource)
        {
            Argument.NotNull(resource, nameof(resource));

            ThrowIfDisposed();

            _resources.Add(resource);
        }

        /// <summary>
        /// Throws <see cref="ObjectDisposedException"/> when this instance has been disposed
        /// </summary>
        /// <returns>This instance</returns>
        /// <exception cref="ObjectDisposedException">This instance has been disposed</exception>
        public DisposableResources ThrowIfDisposed()
        {
            if (IsDisposed == true)
            {
                throw new ObjectDisposedException(nameof(DisposableResources));
            }

            return this;
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
                    foreach (var resource in _resources)
                    {
                        resource.Dispose();
                    }

                    _resources.Clear();
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
