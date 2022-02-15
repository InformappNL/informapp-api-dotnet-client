using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Validate queue integration import decorator
    /// </summary>
    public class ValidateQueueIntegrationImportDecorator : Decorator<IQueueIntegrationImportCommandHandler>,
        IQueueIntegrationImportCommandHandler
    {
        private readonly IQueueIntegrationImportCommandHandler _handler;

        private readonly IValidator<QueueIntegrationImportCommand> _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateQueueIntegrationImportDecorator"/> class.
        /// </summary>
        public ValidateQueueIntegrationImportDecorator(
            IQueueIntegrationImportCommandHandler handler,
            IValidator<QueueIntegrationImportCommand> validator) : base(handler)
        {
            _handler = handler;

            _validator = validator;
        }

        /// <inheritdoc/>
        public Task<QueueIntegrationImportCommandResult> Handle(
            QueueIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            if (command != null)
            {
                _validator.ValidateObject(command);
            }

            return _handler.Handle(command, cancellationToken);
        }
    }
}
