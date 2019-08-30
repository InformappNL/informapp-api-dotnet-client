
namespace Informapp.InformSystem.WebApi.Client.Converters
{
    /// <summary>
    /// Static class aiding in creation of <see cref="ConvertResult{T}"/> objects
    /// </summary>
    public static class ConvertResult
    {
        /// <summary>
        /// Create <see cref="ConvertResult{T}"/> for any type
        /// </summary>
        /// <typeparam name="T">The type converted to</typeparam>
        /// <param name="value">The value</param>
        /// <param name="hasValue">true if <paramref name="value"/> is considered a valid value; else false</param>
        /// <returns>new instance of <see cref="ConvertResult{T}"/></returns>
        public static ConvertResult<T> From<T>(T value, bool hasValue)
        {
            return new ConvertResult<T>(value, hasValue);
        }

        /// <summary>
        /// Create <see cref="ConvertResult{T}"/> for reference type
        /// </summary>
        /// <typeparam name="T">The type converted to</typeparam>
        /// <param name="value">The value</param>
        /// <returns>A new instance of <see cref="ConvertResult{T}"/></returns>
        public static ConvertResult<T> FromReference<T>(T value)
            where T : class
        {
            return new ConvertResult<T>(value, value != null);
        }

        /// <summary>
        /// Create <see cref="ConvertResult{T}"/> for value type
        /// </summary>
        /// <typeparam name="T">The type converted to</typeparam>
        /// <param name="value">The value</param>
        /// <returns>A new instance of <see cref="ConvertResult{T}"/></returns>
        public static ConvertResult<T> FromValue<T>(T value)
            where T : struct
        {
            return new ConvertResult<T>(value, hasValue: true);
        }

        /// <summary>
        /// Create <see cref="ConvertResult{T}"/> for value type
        /// </summary>
        /// <typeparam name="T">The type converted to</typeparam>
        /// <param name="value">The value</param>
        /// <returns>A new instance of <see cref="ConvertResult{T}"/></returns>
        public static ConvertResult<T> FromValue<T>(T? value)
            where T : struct
        {
            return new ConvertResult<T>(value.GetValueOrDefault(), value.HasValue);
        }

        /// <summary>
        /// Create <see cref="ConvertResult{T}"/> for nullable value type
        /// </summary>
        /// <typeparam name="T">The type converted to</typeparam>
        /// <param name="value">The value</param>
        /// <returns>A new instance of <see cref="ConvertResult{T}"/></returns>
        public static ConvertResult<T?> FromNullable<T>(T value)
            where T : struct
        {
            return new ConvertResult<T?>(value, hasValue: true);
        }

        /// <summary>
        /// Create <see cref="ConvertResult{T}"/> for nullable value type
        /// </summary>
        /// <typeparam name="T">The type converted to</typeparam>
        /// <param name="value">The value</param>
        /// <returns>A new instance of <see cref="ConvertResult{T}"/></returns>
        public static ConvertResult<T?> FromNullable<T>(T? value)
            where T : struct
        {
            return new ConvertResult<T?>(value, value.HasValue);
        }

        /// <summary>
        /// Create empty <see cref="ConvertResult{T}"/> 
        /// </summary>
        /// <typeparam name="T">The type converted to</typeparam>
        /// <returns>A new instance of <see cref="ConvertResult{T}"/></returns>
        public static ConvertResult<T> Empty<T>()
        {
            return new ConvertResult<T>(default(T), hasValue: false);
        }

        /// <summary>
        /// Create empty <see cref="ConvertResult{T}"/> 
        /// </summary>
        /// <typeparam name="T">The type converted to</typeparam>
        /// <param name="value">The value</param>
        /// <returns>A new instance of <see cref="ConvertResult{T}"/></returns>
        public static ConvertResult<T> Empty<T>(T value)
        {
            return new ConvertResult<T>(value, hasValue: false);
        }
    }
}
