using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationExports
{
    /// <summary>
    /// Decorator class for <see cref="IDownloadIntegrationExportCommandHandler"/> to log debug information
    /// </summary>
    public class DebugDownloadIntegrationExportCommandHandlerDecorator : Decorator<IDownloadIntegrationExportCommandHandler>,
        IDownloadIntegrationExportCommandHandler
    {
        private readonly IDownloadIntegrationExportCommandHandler _handler;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationDownloadIntegrationExportCommandHandlerDecorator"/> class
        /// </summary>
        /// <param name="handler">The instance to decorate</param>
        /// <param name="logger">The logger</param>
        public DebugDownloadIntegrationExportCommandHandlerDecorator(
            IDownloadIntegrationExportCommandHandler handler,
            IApplicationLogger logger) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(logger, nameof(logger));

            _handler = handler;

            _logger = logger;
        }

        /// <summary>
        /// Log debug information
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<DownloadIntegrationExportCommandResult> Handle(
            DownloadIntegrationExportCommand command,
            CancellationToken cancellationToken)
        {
            if (_logger.IsDebugEnabled)
            {
                return HandleWithDebug(command, cancellationToken);
            }
            else
            {
                return _handler.Handle(command, cancellationToken);
            }
        }

        private async Task<DownloadIntegrationExportCommandResult> HandleWithDebug(
            DownloadIntegrationExportCommand command,
            CancellationToken cancellationToken)
        {
            const string commandName = nameof(DownloadIntegrationExportCommand);

            _logger.DebugFormat(
                "Executing command {0} :\r\n{1}",
                commandName,
                _logger.Serialize(command));

            var commandResult = await _handler
                .Handle(command, cancellationToken)
                .ConfigureAwait(Await.Default);

            _logger.DebugFormat(
                "Executed command {0} :\r\n{1}",
                commandName,
                _logger.Serialize(commandResult));

            return commandResult;
        }
    }
}
