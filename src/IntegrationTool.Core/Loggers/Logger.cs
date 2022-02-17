using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Enums;
using log4net;
using System;
using System.Globalization;

// http://www.codeproject.com/Articles/140911/log-net-Tutorial

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Loggers
{
    /// <summary>
    /// Logger class
    /// </summary>
    public class Logger : IApplicationLogger
    {
        private readonly ILog _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="name">Injected name string</param>
        public Logger(string name)
        {
            Argument.NotNullOrEmpty(name, nameof(name));

            _logger = LogManager.GetLogger(name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="logger">Injected logger</param>
        public Logger(ILog logger)
        {
            Argument.NotNull(logger, nameof(logger));

            _logger = logger;
        }

        /// <summary>
        /// Set debug logging enabled true/false
        /// </summary>
        public bool IsDebugEnabled => _logger.IsDebugEnabled;

        /// <summary>
        /// Set error logging enabled true/false
        /// </summary>
        public bool IsErrorEnabled => _logger.IsErrorEnabled;

        /// <summary>
        /// Set fatal logging enabled true/false
        /// </summary>
        public bool IsFatalEnabled => _logger.IsFatalEnabled;

        /// <summary>
        /// Set info logging enabled true/false
        /// </summary>
        public bool IsInfoEnabled => _logger.IsInfoEnabled;

        /// <summary>
        /// Set warn logging enabled true/false
        /// </summary>
        public bool IsWarnEnabled => _logger.IsWarnEnabled;

        /// <summary>
        /// Check if loglevel is enabled
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool IsEnabledFor(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Off:
                    return false;
                case LogLevel.Fatal:
                    return IsFatalEnabled;
                case LogLevel.Error:
                    return IsErrorEnabled;
                case LogLevel.Warn:
                    return IsWarnEnabled;
                case LogLevel.Info:
                    return IsInfoEnabled;
                case LogLevel.Debug:
                    return IsDebugEnabled;
                default:
                    throw UnexpectedEnumValueException.Create(level);
            }
        }

        /// <summary>
        /// Make log from log entry
        /// </summary>
        /// <param name="entry">The log entry</param>
        public void Log(LogEntry entry)
        {
            Argument.NotNull(entry, nameof(entry));

            string message = Format(entry.Format, entry.Args);

            if (entry.Exception == null)
            {
                Log(entry.Level, message);
            }
            else
            {
                Log(entry.Level, message, entry.Exception);
            }
        }

        private static string Format(string format, object[] args)
        {
            string message;
            if (args == null || args.Length == 0)
            {
                message = format;
            }
            else
            {
                message = string.Format(CultureInfo.InvariantCulture, format, args);
            }

            return message;
        }

        private void Log(LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.Off:
                    break;
                case LogLevel.Fatal:
                    _logger.Fatal(message);
                    break;
                case LogLevel.Error:
                    _logger.Error(message);
                    break;
                case LogLevel.Warn:
                    _logger.Warn(message);
                    break;
                case LogLevel.Info:
                    _logger.Info(message);
                    break;
                case LogLevel.Debug:
                    _logger.Debug(message);
                    break;
                default:
                    throw UnexpectedEnumValueException.Create(level);
            }
        }

        private void Log(LogLevel level, string message, Exception exception)
        {
            switch (level)
            {
                case LogLevel.Off:
                    break;
                case LogLevel.Fatal:
                    _logger.Fatal(message, exception);
                    break;
                case LogLevel.Error:
                    _logger.Error(message, exception);
                    break;
                case LogLevel.Warn:
                    _logger.Warn(message, exception);
                    break;
                case LogLevel.Info:
                    _logger.Info(message, exception);
                    break;
                case LogLevel.Debug:
                    _logger.Debug(message, exception);
                    break;
                default:
                    throw UnexpectedEnumValueException.Create(level);
            }
        }
    }
}
