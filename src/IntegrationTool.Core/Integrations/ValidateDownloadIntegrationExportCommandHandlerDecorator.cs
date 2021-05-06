using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Integrations
{
    /// <summary>
    /// Decorator class for <see cref="IDownloadIntegrationExportCommandHandler"/> to validate download integration export command
    /// </summary>
    public class ValidateDownloadIntegrationExportCommandHandlerDecorator : Decorator<IDownloadIntegrationExportCommandHandler>,
        IDownloadIntegrationExportCommandHandler
    {
        private readonly IDownloadIntegrationExportCommandHandler _handler;

        private readonly IValidator<DownloadIntegrationExportCommand> _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateDownloadIntegrationExportCommandHandlerDecorator"/> class.
        /// </summary>
        /// <param name="handler">Injected command handler</param>
        /// <param name="validator">Injected command validator</param>
        public ValidateDownloadIntegrationExportCommandHandlerDecorator(
            IDownloadIntegrationExportCommandHandler handler,
            IValidator<DownloadIntegrationExportCommand> validator) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(validator, nameof(validator));

            _handler = handler;

            _validator = validator;
        }

        /// <summary>
        /// Validate download integration export command
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<DownloadIntegrationExportCommandResult> Handle(
            DownloadIntegrationExportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            _validator.ValidateObject(command);

            return _handler.Handle(command, cancellationToken);
        }
    }
}
