
using System;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.HashCodes
{
    internal static class HashCodeHelper
    {
        public const int DefaultValue = 0;

        public const int DefaultInitialValue = 17;

        public const int DefaultMultiplication = 23;



        public static int AddRef<T>(int hashCode, T instance)
            where T : class
        {
            return AddRef(hashCode, DefaultMultiplication, instance);
        }

        public static int AddRef<T>(int hashCode, int multiplication, T instance)
            where T : class
        {
            if (instance is null)
            {
                hashCode = AddNull(hashCode, multiplication);
            }
            else
            {
                hashCode = Add(hashCode, multiplication, instance);
            }

            return hashCode;
        }

        [Obsolete("Use " + nameof(AddString), error: true)]
        public static int AddRef(int hashCode, string instance)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Use " + nameof(AddString), error: true)]
        public static int AddRef(int hashCode, int multiplication, string instance)
        {
            throw new NotImplementedException();
        }


        public static int AddString(int hashCode, string instance, StringComparison comparison)
        {
            return AddString(hashCode, DefaultMultiplication, instance, comparison);
        }

        public static int AddString(int hashCode, int multiplication, string instance, StringComparison comparison)
        {
            if (instance == null)
            {
                hashCode = AddNull(hashCode, multiplication);
            }
            else
            {
                IEqualityComparer<string> comparer;

                switch (comparison)
                {
                    case StringComparison.CurrentCulture:
                        comparer = StringComparer.CurrentCulture;
                        break;
                    case StringComparison.CurrentCultureIgnoreCase:
                        comparer = StringComparer.CurrentCultureIgnoreCase;
                        break;
                    case StringComparison.InvariantCulture:
                        comparer = StringComparer.InvariantCulture;
                        break;
                    case StringComparison.InvariantCultureIgnoreCase:
                        comparer = StringComparer.InvariantCultureIgnoreCase;
                        break;
                    case StringComparison.Ordinal:
                        comparer = StringComparer.Ordinal;
                        break;
                    case StringComparison.OrdinalIgnoreCase:
                        comparer = StringComparer.OrdinalIgnoreCase;
                        break;
                    default:
                        throw new ArgumentException("Unsupported string comparison", nameof(comparison));
                }

                hashCode = Add(hashCode, multiplication, comparer, instance);
            }

            return hashCode;
        }



        public static int AddValue<T>(int hashCode, T instance)
            where T : struct
        {
            return AddValue(hashCode, DefaultMultiplication, instance);
        }

        public static int AddValue<T>(int hashCode, int multiplication, T instance)
            where T : struct
        {
            return Add(hashCode, multiplication, instance);
        }



        public static int AddValue<T>(int hashCode, T? instance)
            where T : struct
        {
            return AddValue(hashCode, DefaultMultiplication, instance);
        }

        public static int AddValue<T>(int hashCode, int multiplication, T? instance)
            where T : struct
        {
            if (instance.HasValue == false)
            {
                hashCode = AddNull(hashCode, multiplication);
            }
            else
            {
                hashCode = Add(hashCode, multiplication, instance.Value);
            }

            return hashCode;
        }



        private static int Add<T>(int hashCode, int multiplication, T instance)
        {
            unchecked
            {
                return (hashCode * multiplication) + instance.GetHashCode();
            }
        }

        private static int Add<T>(int hashCode, int multiplication, IEqualityComparer<T> comparer, T instance)
        {
            unchecked
            {
                return (hashCode * multiplication) + comparer.GetHashCode(instance);
            }
        }

        private static int AddNull(int hashCode, int multiplication)
        {
            unchecked
            {
                return (hashCode * multiplication) + 0;
            }
        }
    }
}
