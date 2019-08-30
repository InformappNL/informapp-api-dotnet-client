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
        /// Path arguments
        /// </summary>
        private string[] Arguments { get; }
            = Array.Empty<string>();

        /// <summary>
        /// Create instance with the specified pattern
        /// </summary>
        /// <param name="pattern">Path pattern</param>
        /// <exception cref="ArgumentNullException"><paramref name="pattern"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="pattern"/> is empty</exception>
        internal PathAttribute(string pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException(nameof(pattern));
            }

            if (string.IsNullOrEmpty(pattern) == true)
            {
                throw new ArgumentException("Can not be empty", nameof(pattern));
            }

            Pattern = pattern;
        }

        /// <summary>
        /// Create instance with the specified pattern and arguments
        /// </summary>
        /// <param name="pattern">Path pattern</param>
        /// <param name="arguments">Path arguments</param>
        /// <exception cref="ArgumentNullException"><paramref name="pattern"/> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="arguments"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="pattern"/> is empty</exception>
        /// <exception cref="ArgumentException"><paramref name="arguments"/> is empty</exception>
        private PathAttribute(
            string pattern, params string[] arguments) : this(pattern)
        {
            if (arguments == null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            if (arguments.Length == 0)
            {
                throw new ArgumentException("Can not be empty", nameof(arguments));
            }

            Arguments = arguments;
        }
    }
}
