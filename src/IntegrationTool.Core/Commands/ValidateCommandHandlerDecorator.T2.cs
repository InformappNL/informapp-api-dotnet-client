using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands
{
    /// <summary>
    /// Decorator class for <see cref="ICommandHandler{TCommand, TResult}"/> to validate command on execution
    /// </summary>
    public class ValidateCommandHandlerDecorator<TCommand, TResult> :
        Decorator<ICommandHandler<TCommand, TResult>>,
        ICommandHandler<TCommand, TResult>

        where TCommand : class, ICommand<TResult>
        where TResult : class
    {
        private readonly ICommandHandler<TCommand, TResult> _commandHandler;

        private readonly IValidator<TCommand> _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateCommandHandlerDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="commandHandler">The instance to decorate</param>
        /// <param name="validator">The validator to decorate</param>
        public ValidateCommandHandlerDecorator(
            ICommandHandler<TCommand, TResult> commandHandler,
            IValidator<TCommand> validator) : base(commandHandler)
        {
            _commandHandler = commandHandler;

            _validator = validator;
        }

        /// <summary>
        /// Validate and execute command if valid
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<TResult> Handle(TCommand command, CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            _validator.ValidateObject(command);

            return _commandHandler.Handle(command, cancellationToken);
        }
    }
}
