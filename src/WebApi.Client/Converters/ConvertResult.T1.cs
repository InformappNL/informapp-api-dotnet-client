
namespace Informapp.InformSystem.WebApi.Client.Converters
{
    /// <summary>
    /// Gerneric class representing the result of a conversion
    /// </summary>
    /// <typeparam name="T">The type converted to</typeparam>
    public class ConvertResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConvertResult{T}"/> class.
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="hasValue">true if <paramref name="value"/> is considered a valid value; else false</param>
        public ConvertResult(T value, bool hasValue)
        {
            Value = value;

            HasValue = hasValue;
        }

        /// <summary>
        /// Gets the value
        /// </summary>
        /// <returns>The value</returns>
        public T Value { get; }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="ConvertResult{T}"/> object holds a valid value.
        /// </summary>
        /// <returns>true if the current <see cref="ConvertResult{T}"/> object has a value; false if the current <see cref="ConvertResult{T}"/> object has no value.</returns>
        public bool HasValue { get; }
    }
}
