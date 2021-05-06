using System;

namespace Informapp.InformSystem.IntegrationTool.Core.Loggers
{
    /// <summary>
    /// Application logger extension methods
    /// </summary>
    public static partial class ApplicationLoggerExtensions
    {
        private static LogEntry LogEntry(LogLevel level, string message)
        {
            // Empty is allowed
            Argument.NotNull(message, nameof(message));

            var entry = new LogEntry(level, message, null);

            return entry;
        }

        private static LogEntry LogEntry(LogLevel level, string format, params object[] args)
        {
            // Empty is allowed
            Argument.NotNull(format, nameof(format));

            var entry = new LogEntry(level, format, args);

            return entry;
        }

        private static LogEntry LogEntry(LogLevel level, Exception exception, string format, params object[] args)
        {
            // Empty is allowed
            Argument.NotNull(format, nameof(format));

            var entry = new LogEntry(level, format, args, exception);

            return entry;
        }
    }
}
