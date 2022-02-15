using Informapp.InformSystem.IntegrationTool.Core.Loggers;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands
{
    public class DebugCommandHandlerDecorator<TCommand, TResult> : Decorator<ICommandHandler<TCommand, TResult>>,
        ICommandHandler<TCommand, TResult>

        where TCommand : class, ICommand<TResult>
        where TResult : class
    {
        private readonly ICommandHandler<TCommand, TResult> _handler;

        private readonly IApplicationLogger _logger;

        public DebugCommandHandlerDecorator(
            ICommandHandler<TCommand, TResult> handler,
            IApplicationLogger logger) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(logger, nameof(logger));

            _handler = handler;

            _logger = logger;
        }

        public Task<TResult> Handle(TCommand command, CancellationToken cancellationToken)
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

        private async Task<TResult> HandleWithDebug(TCommand command, CancellationToken cancellationToken)
        {
            string commandName = typeof(TCommand).Name;

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
