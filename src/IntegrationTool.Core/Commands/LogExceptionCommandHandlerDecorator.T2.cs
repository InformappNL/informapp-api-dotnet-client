using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands
{
    public class LogExceptionCommandHandlerDecorator<TCommand, TResult> : Decorator<ICommandHandler<TCommand, TResult>>,
        ICommandHandler<TCommand, TResult>

        where TCommand : class, ICommand<TResult>
        where TResult : class
    {
        private readonly ICommandHandler<TCommand, TResult> _handler;

        private readonly IApplicationLogger _logger;

        public LogExceptionCommandHandlerDecorator(
            ICommandHandler<TCommand, TResult> handler,
            IApplicationLogger logger) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(logger, nameof(logger));

            _handler = handler;

            _logger = logger;
        }

        public Task<TResult> Handle(
            TCommand command,
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

        private async Task<TResult> HandleWithErrorLogging(
            TCommand command,
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
                string commandName = typeof(TCommand).Name;

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
