using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationExports
{
    /// <summary>
    /// Decorator class for <see cref="IDownloadIntegrationExportCommandHandler"/> to accept a download
    /// </summary>
    public class AcceptDownloadIntegrationExportCommandHandlerDecorator : Decorator<IDownloadIntegrationExportCommandHandler>,
        IDownloadIntegrationExportCommandHandler
    {
        private readonly IDownloadIntegrationExportCommandHandler _handler;

        private readonly IApiClient<AcceptIntegrationExportV1Request, AcceptIntegrationExportV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AcceptDownloadIntegrationExportCommandHandlerDecorator"/> class.
        /// </summary>
        /// <param name="handler">The instance to decorate</param>
        /// <param name="client">The client instance to decorate</param>
        public AcceptDownloadIntegrationExportCommandHandlerDecorator(
            IDownloadIntegrationExportCommandHandler handler,
            IApiClient<AcceptIntegrationExportV1Request, AcceptIntegrationExportV1Response> client) : base(handler)
        {
            _handler = handler;

            _client = client;
        }

        /// <summary>
        /// Handle command
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<DownloadIntegrationExportCommandResult> Handle(
            DownloadIntegrationExportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            DownloadIntegrationExportCommandResult commandResult;

            var request = new AcceptIntegrationExportV1Request
            {
                IntegrationExportId = command.IntegrationExportId,
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            if (response.IsSuccessful)
            {
                command.IntegrationExportLogId = response.Model.IntegrationExportLogId;

                commandResult = await _handler
                    .Handle(command, cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
            else
            {
                commandResult = new DownloadIntegrationExportCommandResult
                {
                    Success = false,
                    Message = "Error accepting integration export",
                };
            }

            return commandResult;
        }
    }
}
