using Informapp.InformSystem.WebApi.Client.Decorators;
using System;

namespace Informapp.InformSystem.IntegrationTool.Core.Loggers
{
    public class LogExceptionApplicationLoggerDecorator : Decorator<IApplicationLogger>,
        IApplicationLogger
    {
        private readonly IApplicationLogger _logger;

        public LogExceptionApplicationLoggerDecorator(
            IApplicationLogger logger) : base(logger)
        {
            Argument.NotNull(logger, nameof(logger));

            _logger = logger;
        }

        public bool IsDebugEnabled => _logger.IsDebugEnabled;

        public bool IsErrorEnabled => _logger.IsErrorEnabled;

        public bool IsFatalEnabled => _logger.IsFatalEnabled;

        public bool IsInfoEnabled => _logger.IsInfoEnabled;

        public bool IsWarnEnabled => _logger.IsWarnEnabled;

        public bool IsEnabledFor(LogLevel level)
        {
            return _logger.IsEnabledFor(level);
        }

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
