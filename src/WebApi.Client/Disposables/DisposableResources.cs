using Informapp.InformSystem.WebApi.Client.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed == false)
            {
                foreach (var resource in _resources)
                {
                    resource.Dispose();
                }

                _resources.Clear();

                IsDisposed = true;
            }
        }
    }
}
