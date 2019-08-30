using System;
using System.Globalization;

namespace Informapp.InformSystem.WebApi.Client.Sample.Requires
{
    /// <summary>
    /// Static class with methods to ensure conditions are true
    /// </summary>
    internal static class Require
    {
        /// <summary>
        /// Ensure an instance is not null
        /// </summary>
        /// <typeparam name="T">Type of object to check</typeparam>
        /// <param name="instance">The instance to check</param>
        /// <param name="parameterName">The name of the parameter</param>
        /// <exception cref="InvalidOperationException"><paramref name="instance"/> is null</exception>
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
        /// <exception cref="InvalidOperationException"><paramref name="instance"/> is null</exception>
        public static void NotNull<T>(T instance, string parameterName)
            where T : class
        {
            if (instance is null)
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
        /// <exception cref="InvalidOperationException"><paramref name="instance"/> is null</exception>
        public static void NotNull<T>(T? instance, string parameterName)
            where T : struct
        {
            if (instance.HasValue == false)
            {
                ThrowNull(parameterName);
            }
        }

        /// <summary>
        /// Determines whether an instance of type <typeparamref name="TSource"/> can be assigned to an instance of type <typeparamref name="TTarget"/>.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        public static void Assignable<TSource, TTarget>()
            where TSource : TTarget
        {

        }

        private static bool IsNull<T>(T instance)
        {
            return ReferenceEquals(null, instance);
        }

        private static void ThrowNull(string parameterName)
        {
            var message = string.Format(CultureInfo.InvariantCulture, "{0} can not be null", parameterName);

            throw new InvalidOperationException(message);
        }
    }
}
