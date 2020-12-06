using Informapp.InformSystem.WebApi.Models.Arguments;
using System;

namespace Informapp.InformSystem.WebApi.Models.Http
{
    /// <summary>
    /// Set path for a request class
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class PathAttribute : Attribute
    {
        /// <summary>
        /// Path pattern
        /// </summary>
        public string Pattern { get; }

        /// <summary>
        /// Create instance with the specified pattern
        /// </summary>
        /// <param name="pattern">Path pattern</param>
        /// <exception cref="ArgumentNullException"><paramref name="pattern"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="pattern"/> is empty</exception>
        public PathAttribute(string pattern)
        {
            Argument.NotNullOrEmpty(pattern, nameof(pattern));

            Pattern = pattern;
        }
    }
}
