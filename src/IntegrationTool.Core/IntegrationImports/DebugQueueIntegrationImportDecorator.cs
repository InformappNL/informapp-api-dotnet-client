﻿using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    public class DebugQueueIntegrationImportDecorator : Decorator<IQueueIntegrationImportCommandHandler>,
        IQueueIntegrationImportCommandHandler
    {
        private readonly IQueueIntegrationImportCommandHandler _handler;

        private readonly IApplicationLogger _logger;

        public DebugQueueIntegrationImportDecorator(
            IQueueIntegrationImportCommandHandler handler,
            IApplicationLogger logger) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(logger, nameof(logger));

            _handler = handler;

            _logger = logger;
        }

        public Task<QueueIntegrationImportCommandResult> Handle(
            QueueIntegrationImportCommand command,
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

        private async Task<QueueIntegrationImportCommandResult> HandleWithDebug(
            QueueIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            const string commandName = nameof(QueueIntegrationImportCommand);

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
