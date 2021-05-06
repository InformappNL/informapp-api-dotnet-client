using System;

namespace Informapp.InformSystem.IntegrationTool.Core.Loggers
{
    /// <summary>
    /// Application logger extension methods for log
    /// </summary>
    public static partial class ApplicationLoggerExtensions
    {
        /// <summary>
        /// Add message to the log
        /// </summary>
        /// <param name="logger">The application logger</param>
        /// <param name="level">The log level</param>
        /// <param name="message">The message string</param>
        public static void Log(this IApplicationLogger logger, LogLevel level, string message)
        {
            Argument.NotNull(logger, nameof(logger));

            logger.Log(LogEntry(level, message, null));
        }

        /// <summary>
        /// Add message and exception to the log
        /// </summary>
        /// <param name="logger">The application logger</param>
        /// <param name="level">The log level</param>
        /// <param name="exception">The thrown exception</param>
        /// <param name="message">The message string</param>
        public static void Log(this IApplicationLogger logger, LogLevel level, Exception exception, string message)
        {
            Argument.NotNull(logger, nameof(logger));

            logger.Log(LogEntry(level, exception, message, null));
        }

        /// <summary>
        /// Add format string and additional arguments to log
        /// </summary>
        /// <param name="logger">The application logger</param>
        /// <param name="level">The log level</param>
        /// <param name="format">The format string</param>
        /// <param name="args">Additional arguments</param>
        public static void Log(this IApplicationLogger logger, LogLevel level, string format, params object[] args)
        {
            Argument.NotNull(logger, nameof(logger));

            logger.Log(LogEntry(level, format, args));
        }

        /// <summary>
        /// Add exception, format string and additional arguments to log
        /// </summary>
        /// <param name="logger">The application logger</param>
        /// <param name="level">The log level</param>
        /// <param name="exception">The thrown exception</param>
        /// <param name="format">The format string</param>
        /// <param name="args">Additional arguments</param>
        public static void Log(this IApplicationLogger logger, LogLevel level, Exception exception, string format, params object[] args)
        {
            Argument.NotNull(logger, nameof(logger));

            logger.Log(LogEntry(level, exception, format, args));
        }
    }
}
