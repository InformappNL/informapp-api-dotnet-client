using System;
using System.Globalization;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Requires
{
    /// <summary>
    /// Generic Require{T} methods
    /// </summary>
    public static class Require
    {
        /// <summary>
        /// Require T, T can not be null
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="instance">Actual value for T</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void Required<T>(T instance, string parameterName)
        {
            if (IsNull(instance) == true)
            {
                ThrowNull(parameterName);
            }
        }

        /// <summary>
        /// T can not be null
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="instance">Actual value for T</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void NotNull<T>(T instance, string parameterName)
            where T : class
        {
            if (instance is null)
            {
                ThrowNull(parameterName);
            }
        }

        /// <summary>
        /// T can not be null, but T is nullable
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="instance">Actual value for T</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void NotNull<T>(T? instance, string parameterName)
            where T : struct
        {
            if (instance.HasValue == false)
            {
                ThrowNull(parameterName);
            }
        }

        /// <summary>
        /// String can not be null or empty
        /// </summary>
        /// <param name="instance">String value</param>
        /// <param name="parameterName">Parameter name</param>
        public static void NotNullOrEmpty(string instance, string parameterName)
        {
            if (string.IsNullOrEmpty(instance))
            {
                ThrowNullOrEmpty(parameterName);
            }
        }

        /// <summary>
        /// Check if TSource is assignable to TTarget
        /// </summary>
        /// <typeparam name="TSource">Type of source</typeparam>
        /// <typeparam name="TTarget">Type of target</typeparam>
        public static void Assignable<TSource, TTarget>()
            where TSource : TTarget
        {

        }

        /// <summary>
        /// Condition on T must be true
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="instance">Actual value for T</param>
        /// <param name="condition">Condition that has to be true with value of T</param>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="conditionName">Name of the condition</param>
        public static void MustBeTrue<T>(T instance, bool condition, string parameterName, string conditionName)
        {
            _ = instance;

            if (condition == false)
            {
                ThrowCondition(parameterName, conditionName);
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
            var message = string.Format(CultureInfo.InvariantCulture, "{0} can not be null", parameterName);

            throw new InvalidOperationException(message);
        }

        private static void ThrowNullOrEmpty(string parameterName)
        {
            var message = string.Format(CultureInfo.InvariantCulture, "{0} can not be null or empty", parameterName);

            throw new InvalidOperationException(message);
        }

        private static void ThrowCondition(string parameterName, string conditionName)
        {
            var message = string.Format(CultureInfo.InvariantCulture, "{0} condition {1} must be true", parameterName, conditionName);

            throw new InvalidOperationException(message);
        }
    }
}
