
namespace Informapp.InformSystem.IntegrationTool.Core.Loggers
{
    /// <summary>
    /// Interface for application logger
    /// </summary>
    public interface IApplicationLogger
    {
        /// <summary>
        /// Is debug enabled true/false
        /// </summary>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// Is error enabled true/false
        /// </summary>
        bool IsErrorEnabled { get; }

        /// <summary>
        /// Is fatal enabled true/false
        /// </summary>
        bool IsFatalEnabled { get; }

        /// <summary>
        /// Is info enabled true/false
        /// </summary>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Is warn enabled true/false
        /// </summary>
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Is logging enabled for specific log level true/false
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnabledFor(LogLevel level);

        /// <summary>
        /// Log entry
        /// </summary>
        /// <param name="entry"></param>
        void Log(LogEntry entry);
    }
}
