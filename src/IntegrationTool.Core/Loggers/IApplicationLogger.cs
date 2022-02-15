
namespace Informapp.InformSystem.IntegrationTool.Core.Loggers
{
    /// <summary>
    /// Logger abstraction
    /// </summary>
    public interface IApplicationLogger
    {
        /// <summary>
        /// Debug enabled
        /// </summary>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// Error enabled
        /// </summary>
        bool IsErrorEnabled { get; }

        /// <summary>
        /// Fatal enabled
        /// </summary>
        bool IsFatalEnabled { get; }

        /// <summary>
        /// Info enabled
        /// </summary>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Warn enabled
        /// </summary>
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Enabled for a given log level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnabledFor(LogLevel level);

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="entry">The content to log</param>
        void Log(LogEntry entry);
    }
}
