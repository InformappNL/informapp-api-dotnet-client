using System;

namespace Informapp.InformSystem.WebApi.Client.Disposables
{
    /// <summary>
    /// Represents a collection of <see cref="IDisposable"/> resources
    /// </summary>
    public interface IDisposableResources : IDisposable
    {
        /// <summary>
        /// Indicates whether this object has been disposed
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Register the <see cref="IDisposable"/> resource for disposal
        /// </summary>
        /// <param name="resource">The resource</param>
        void RegisterForDisposal(IDisposable resource);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void Dispose();
    }
}
