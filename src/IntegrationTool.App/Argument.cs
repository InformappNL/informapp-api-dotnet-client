using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Informapp
{
    [DebuggerStepThrough]
    internal static class Argument
    {
        public static void Required<T>(T instance, string parameterName)
        {
            if (IsNull(instance) == true)
            {
                ThrowNull(parameterName);
            }
        }

        public static void NotNull<T>(T instance, string parameterName)
            where T : class
        {
            if (IsNull(instance))
            {
                ThrowNull(parameterName);
            }
        }

        public static void NotNull<T>(T? instance, string parameterName)
            where T : struct
        {
            if (instance.HasValue == false)
            {
                ThrowNull(parameterName);
            }
        }

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
#pragma warning disable CA1303 // Do not pass literals as localized parameters
            throw new ArgumentException("Can not be empty", parameterName);
#pragma warning restore CA1303 // Do not pass literals as localized parameters
        }
    }
}
