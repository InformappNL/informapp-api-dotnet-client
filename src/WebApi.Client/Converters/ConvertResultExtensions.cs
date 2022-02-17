using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Converters
{
    /// <summary>
    /// Static class holding extensions for <see cref="ConvertResult{T}"/>
    /// </summary>
    public static class ConvertResultExtensions
    {
        /// <summary>
        /// Throw exception when a <see cref="ConvertResult{T}"/> holds no value
        /// </summary>
        /// <typeparam name="T">The type converted to</typeparam>
        /// <param name="convertResult">The converted result</param>
        /// <returns>The converted result</returns>
        /// <exception cref="ArgumentNullException"><paramref name="convertResult"/> is null.</exception>
        /// <exception cref="InvalidOperationException">The <see cref="ConvertResult{T}.HasValue"/> property is false.</exception>
        public static ConvertResult<T> ThrowIfNoValue<T>(this ConvertResult<T> convertResult)
        {
            Argument.NotNull(convertResult, nameof(convertResult));

            if (convertResult.HasValue == false)
            {
                throw new InvalidOperationException("No value");
            }

            return convertResult;
        }
    }
}
