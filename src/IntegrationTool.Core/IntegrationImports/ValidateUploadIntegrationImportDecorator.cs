using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Decorator class for <see cref="IUploadIntegrationImportCommandHandler"/> to validate upload integration import command
    /// </summary>
    public class ValidateUploadIntegrationImportDecorator : Decorator<IUploadIntegrationImportCommandHandler>,
        IUploadIntegrationImportCommandHandler
    {
        private readonly IUploadIntegrationImportCommandHandler _handler;

        private readonly IValidator<UploadIntegrationImportCommand> _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateUploadIntegrationImportDecorator"/> class.
        /// </summary>
        /// <param name="handler">Injected command handler</param>
        /// <param name="validator">Injected command validator</param>
        public ValidateUploadIntegrationImportDecorator(
            IUploadIntegrationImportCommandHandler handler,
            IValidator<UploadIntegrationImportCommand> validator) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(validator, nameof(validator));

            _handler = handler;

            _validator = validator;
        }

        /// <summary>
        /// Validate upload integration import command
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<UploadIntegrationImportCommandResult> Handle(
            UploadIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            _validator.ValidateObject(command);

            return _handler.Handle(command, cancellationToken);
        }
    }
}
