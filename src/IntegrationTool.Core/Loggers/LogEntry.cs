using System;
using System.ComponentModel;

namespace Informapp.InformSystem.IntegrationTool.Core.Loggers
{
    /// <summary>
    /// Log entry class
    /// </summary>
    public sealed class LogEntry
    {
        /// <summary>
        /// Log level for log entry
        /// </summary>
        public LogLevel Level { get; }

        /// <summary>
        /// Log format string
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// Additional arguments
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public object[] Args { get; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The exception that was throw
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        /// <param name="level">Injected log level</param>
        /// <param name="format">Injected format string</param>
        /// <param name="args">Injected additional arguments</param>
        public LogEntry(LogLevel level, string format, object[] args) :
            this(level, format, args, null)
        {

        }

        /// <summary>
        /// Fill in log entry
        /// </summary>
        /// <param name="level">Log level for log entry</param>
        /// <param name="format">Log format string</param>
        /// <param name="args">Additional arguments</param>
        /// <param name="exception">The exception that was throw</param>
        public LogEntry(LogLevel level, string format, object[] args, Exception exception)
        {
            // Empty is allowed
            Argument.NotNull(format, nameof(format));

            if (IsValid(level) == false)
            {
                throw new InvalidEnumArgumentException(nameof(level), (int)level, typeof(LogLevel));
            }

            Level = level;

            Format = format;

            Args = args;

            Exception = exception;
        }

        private static bool IsValid(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Off:
                case LogLevel.Fatal:
                case LogLevel.Error:
                case LogLevel.Warn:
                case LogLevel.Info:
                case LogLevel.Debug:
                    return true;
                default:
                    return false;
            }
        }
    }
}
