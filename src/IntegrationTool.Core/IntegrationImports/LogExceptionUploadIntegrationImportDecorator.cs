using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Loggers;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Log exception upload integration import decorator
    /// </summary>
    public class LogExceptionUploadIntegrationImportDecorator : Decorator<IUploadIntegrationImportCommandHandler>,
        IUploadIntegrationImportCommandHandler
    {
        private readonly IUploadIntegrationImportCommandHandler _handler;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogExceptionUploadIntegrationImportDecorator"/> class.
        /// </summary>
        public LogExceptionUploadIntegrationImportDecorator(
            IUploadIntegrationImportCommandHandler handler,
            IApplicationLogger logger) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(logger, nameof(logger));

            _handler = handler;

            _logger = logger;
        }

        /// <summary>
        /// Handle the command
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The result</returns>
        public Task<UploadIntegrationImportCommandResult> Handle(
            UploadIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            if (_logger.IsErrorEnabled)
            {
                return HandleWithErrorLogging(command, cancellationToken);
            }
            else
            {
                return _handler.Handle(command, cancellationToken);
            }
        }

        private async Task<UploadIntegrationImportCommandResult> HandleWithErrorLogging(
            UploadIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var commandResult = await _handler
                    .Handle(command, cancellationToken)
                    .ConfigureAwait(Await.Default);

                return commandResult;
            }
            catch (Exception ex)
            {
                const string commandName = nameof(UploadIntegrationImportCommand);

                _logger.ErrorFormat(
                    ex,
                    "Error executing command {0} :\r\n{1}",
                    commandName,
                    _logger.Serialize(command));

                throw;
            }
        }
    }
}
