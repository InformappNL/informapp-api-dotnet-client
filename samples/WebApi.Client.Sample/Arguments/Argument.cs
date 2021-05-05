using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Informapp.InformSystem.WebApi.Client.Sample.Arguments
{
    /// <summary>
    /// Static class with methods to ensure conditions for arguments are true
    /// </summary>
    [DebuggerStepThrough]
    internal static class Argument
    {
        /// <summary>
        /// Ensure an instance is not null
        /// </summary>
        /// <typeparam name="T">Type of object to check</typeparam>
        /// <param name="instance">The instance to check</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is null</exception>
        public static void Required<T>(T instance, string parameterName)
        {
            if (IsNull(instance) == true)
            {
                ThrowNull(parameterName);
            }
        }

        /// <summary>
        /// Ensure a reference type instance is not null
        /// </summary>
        /// <typeparam name="T">Type of object to check</typeparam>
        /// <param name="instance">The instance to check</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is null</exception>
        public static void NotNull<T>(T instance, string parameterName)
            where T : class
        {
            if (IsNull(instance))
            {
                ThrowNull(parameterName);
            }
        }

        /// <summary>
        /// Ensure an nullable value type instance is not null
        /// </summary>
        /// <typeparam name="T">Type of object to check</typeparam>
        /// <param name="instance">The instance to check</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is null</exception>
        public static void NotNull<T>(T? instance, string parameterName)
            where T : struct
        {
            if (instance.HasValue == false)
            {
                ThrowNull(parameterName);
            }
        }

        /// <summary>
        /// Ensure a string is not null or empty
        /// </summary>
        /// <param name="instance">The instance to check</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="instance"/> is empty</exception>
        public static void NotNullOrEmpty(string instance, string parameterName)
        {
            if (IsNull(instance) == true)
            {
                ThrowNull(parameterName);
            }

            if (string.IsNullOrEmpty(instance) == true)
            {
                ThrowEmpty(parameterName);
            }
        }

        /// <summary>
        /// Ensure a collection is not null or empty
        /// </summary>
        /// <typeparam name="T">Type of objects in the collection</typeparam>
        /// <param name="instance">The instance to check</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="instance"/> is empty</exception>
        public static void NotNullOrEmpty<T>(IEnumerable<T> instance, string parameterName)
        {
            if (IsNull(instance) == true)
            {
                ThrowNull(parameterName);
            }

            if (instance.Any() == false)
            {
                ThrowEmpty(parameterName);
            }
        }

        private static bool IsNull<T>(T instance)
        {
#pragma warning disable IDE0041 // Use 'is null' check
            return ReferenceEquals(null, instance);
#pragma warning restore IDE0041 // Use 'is null' check
        }

        private static void ThrowNull(string parameterName)
        {
            throw new ArgumentNullException(parameterName);
        }

        private static void ThrowEmpty(string parameterName)
        {
            throw new ArgumentException("Can not be empty", parameterName);
        }
    }
}
