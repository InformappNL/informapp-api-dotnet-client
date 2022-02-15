using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    public class LogExceptionUploadIntegrationImportDecorator : Decorator<IUploadIntegrationImportCommandHandler>,
        IUploadIntegrationImportCommandHandler
    {
        private readonly IUploadIntegrationImportCommandHandler _handler;

        private readonly IApplicationLogger _logger;

        public LogExceptionUploadIntegrationImportDecorator(
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
