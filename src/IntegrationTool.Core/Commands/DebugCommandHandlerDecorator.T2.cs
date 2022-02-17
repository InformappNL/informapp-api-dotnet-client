using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Loggers;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands
{
    /// <summary>
    /// Debug command handler decorator
    /// </summary>
    public class DebugCommandHandlerDecorator<TCommand, TResult> : Decorator<ICommandHandler<TCommand, TResult>>,
        ICommandHandler<TCommand, TResult>

        where TCommand : class, ICommand<TResult>
        where TResult : class
    {
        private readonly ICommandHandler<TCommand, TResult> _handler;

        private readonly IApplicationLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugCommandHandlerDecorator{TCommand, TResult}"/> class.
        /// </summary>
        public DebugCommandHandlerDecorator(
            ICommandHandler<TCommand, TResult> handler,
            IApplicationLogger logger) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(logger, nameof(logger));

            _handler = handler;

            _logger = logger;
        }

        /// <summary>
        /// Handle the command and return the result
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The result</returns>
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
