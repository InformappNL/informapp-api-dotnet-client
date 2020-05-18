using System;

namespace Informapp.InformSystem.WebApi.Client.Disposables
{
    /// <summary>
    /// Represents a collection of <see cref="IDisposable"/> resources
    /// </summary>
    public interface IDisposableResources
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
    }
}
