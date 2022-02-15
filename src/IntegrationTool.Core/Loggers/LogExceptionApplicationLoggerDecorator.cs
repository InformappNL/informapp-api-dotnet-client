using Informapp.InformSystem.WebApi.Client.Decorators;
using System;

namespace Informapp.InformSystem.IntegrationTool.Core.Loggers
{
    /// <summary>
    /// Log exception application logger decorator
    /// </summary>
    public class LogExceptionApplicationLoggerDecorator : Decorator<IApplicationLogger>,
        IApplicationLogger
    {
        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogExceptionApplicationLoggerDecorator"/> class.
        /// </summary>
        public LogExceptionApplicationLoggerDecorator(
            IApplicationLogger logger) : base(logger)
        {
            Argument.NotNull(logger, nameof(logger));

            _logger = logger;
        }

        /// <inheritdoc/>
        public bool IsDebugEnabled => _logger.IsDebugEnabled;

        /// <inheritdoc/>
        public bool IsErrorEnabled => _logger.IsErrorEnabled;

        /// <inheritdoc/>
        public bool IsFatalEnabled => _logger.IsFatalEnabled;

        /// <inheritdoc/>
        public bool IsInfoEnabled => _logger.IsInfoEnabled;

        /// <inheritdoc/>
        public bool IsWarnEnabled => _logger.IsWarnEnabled;

        /// <inheritdoc/>
        public bool IsEnabledFor(LogLevel level)
        {
            return _logger.IsEnabledFor(level);
        }

        /// <inheritdoc/>
        public void Log(LogEntry entry)
        {
            if (_logger.IsErrorEnabled)
            {
                try
                {
                    _logger.Log(entry);
                }
                catch (Exception ex)
                {
                    _logger.ErrorFormat(
                        ex,
                        "Error logging message:\r\n{0}",
                        _logger.Serialize(entry));

                    throw;
                }
            }
            else
            {
                _logger.Log(entry);
            }
        }
    }
}
