using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.PathProviders
{
    /// <summary>
    /// Generic interface to retrieve path for a class
    /// </summary>
    /// <typeparam name="T">Type to get path from</typeparam>
    public interface IPathProvider<T>
    {
        /// <summary>
        /// Get path for the given instance
        /// </summary>
        /// <param name="instance">Fill path with values from this object</param>
        /// <returns>The path</returns>
        Uri GetPath(T instance);
    }
}
