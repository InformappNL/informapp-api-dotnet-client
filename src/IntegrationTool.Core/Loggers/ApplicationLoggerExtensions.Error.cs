﻿using System;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Loggers
{
    /// <summary>
    /// Application logger extension methods for error
    /// </summary>
    public static partial class ApplicationLoggerExtensions
    {
        /// <summary>
        /// Add message to the log
        /// </summary>
        /// <param name="logger">The application logger</param>
        /// <param name="message">The message string</param>
        public static void Error(this IApplicationLogger logger, string message)
        {
            Argument.NotNull(logger, nameof(logger));

            logger.Log(LogEntry(LogLevel.Error, message));
        }

        /// <summary>
        /// Add message and exception to the log
        /// </summary>
        /// <param name="logger">The application logger</param>
        /// <param name="exception">The thrown exception</param>
        /// <param name="message">The message string</param>
        public static void Error(this IApplicationLogger logger, Exception exception, string message)
        {
            Argument.NotNull(logger, nameof(logger));

            logger.Log(LogEntry(LogLevel.Error, exception, message));
        }

        /// <summary>
        /// Add format string and additional arguments to log
        /// </summary>
        /// <param name="logger">The application logger</param>
        /// <param name="format">The format string</param>
        /// <param name="args">Additional arguments</param>
        public static void ErrorFormat(this IApplicationLogger logger, string format, params object[] args)
        {
            Argument.NotNull(logger, nameof(logger));

            logger.Log(LogEntry(LogLevel.Error, format, args));
        }

        /// <summary>
        /// Add exception, format string and additional arguments to log
        /// </summary>
        /// <param name="logger">The application logger</param>
        /// <param name="exception">The thrown exception</param>
        /// <param name="format">The format string</param>
        /// <param name="args">Additional arguments</param>
        public static void ErrorFormat(this IApplicationLogger logger, Exception exception, string format, params object[] args)
        {
            Argument.NotNull(logger, nameof(logger));

            logger.Log(LogEntry(LogLevel.Error, exception, format, args));
        }
    }
}
