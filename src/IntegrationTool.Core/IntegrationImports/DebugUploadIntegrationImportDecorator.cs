using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    public class DebugUploadIntegrationImportDecorator : Decorator<IUploadIntegrationImportCommandHandler>,
        IUploadIntegrationImportCommandHandler
    {
        private readonly IUploadIntegrationImportCommandHandler _handler;

        private readonly IApplicationLogger _logger;

        public DebugUploadIntegrationImportDecorator(
            IUploadIntegrationImportCommandHandler handler,
            IApplicationLogger logger) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(logger, nameof(logger));

            _handler = handler;

            _logger = logger;
        }

        public Task<UploadIntegrationImportCommandResult> Handle(
            UploadIntegrationImportCommand command,
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

        private async Task<UploadIntegrationImportCommandResult> HandleWithDebug(
            UploadIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            const string commandName = nameof(UploadIntegrationImportCommand);

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
