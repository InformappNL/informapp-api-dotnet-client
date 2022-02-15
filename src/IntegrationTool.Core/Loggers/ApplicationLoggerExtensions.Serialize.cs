using Newtonsoft.Json;

namespace Informapp.InformSystem.IntegrationTool.Core.Loggers
{
    /// <summary>
    /// Application logger extension methods for serialization
    /// </summary>
    public static partial class ApplicationLoggerExtensions
    {
        /// <summary>
        /// Serialize an instance
        /// </summary>
        /// <typeparam name="T">The type of object to serialize</typeparam>
        /// <param name="logger">The logger instance</param>
        /// <param name="value">The instance to serialize</param>
        /// <returns>The serialized value</returns>
        public static string Serialize<T>(this IApplicationLogger logger, T value)
        {
            Argument.NotNull(logger, nameof(logger));

            string serialized = string.Empty;

            if (value != null)
            {
                serialized = JsonConvert.SerializeObject(value);
            }

            return serialized;
        }
    }
}
