using Informapp.InformSystem.WebApi.Client.Arguments;
using System;

namespace Informapp.InformSystem.WebApi.Client.Disposables
{
    /// <summary>
    /// Extension methods for <see cref="IDisposableResources"/>
    /// </summary>
    public static class DisposableResourcesExtensions
    {
        /// <summary>
        /// Try to register a resource for disposal
        /// </summary>
        /// <typeparam name="T">Type of resource</typeparam>
        /// <param name="disposableResources">The instance of <see cref="IDisposableResources"/> to use</param>
        /// <param name="resource">The resource to register for disposal</param>
        /// <returns>true when the <paramref name="resource"/> has been registered for disposal; otherwise false</returns>
        public static bool TryRegisterForDisposal<T>(this IDisposableResources disposableResources, T resource)
            where T : class
        {
            Argument.NotNull(disposableResources, nameof(disposableResources));
            Argument.NotNull(resource, nameof(resource));

            bool registered = false;

            if (resource is IDisposable disposableResource)
            {
                disposableResources.RegisterForDisposal(disposableResource);

                registered = true;
            }

            return registered;
        }

        /// <summary>
        /// Throws <see cref="ObjectDisposedException"/> when the <paramref name="disposableResources"/> instance has been disposed
        /// </summary>
        /// <param name="disposableResources">The instance of <see cref="IDisposableResources"/> to use</param>
        /// <returns>The <paramref name="disposableResources"/> instance</returns>
        public static IDisposableResources ThrowIfDisposed(this IDisposableResources disposableResources)
        {
            Argument.NotNull(disposableResources, nameof(disposableResources));

            if (disposableResources.IsDisposed == true)
            {
                throw new ObjectDisposedException(nameof(DisposableResources));
            }

            return disposableResources;
        }
    }
}
