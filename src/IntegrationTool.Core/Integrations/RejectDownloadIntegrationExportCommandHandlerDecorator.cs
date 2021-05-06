using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Integrations
{
    /// <summary>
    /// Decorator class for <see cref="IDownloadIntegrationExportCommandHandler"/> to reject a download from integration export
    /// </summary>
    public class RejectDownloadIntegrationExportCommandHandlerDecorator : Decorator<IDownloadIntegrationExportCommandHandler>,
        IDownloadIntegrationExportCommandHandler
    {
        private readonly IDownloadIntegrationExportCommandHandler _handler;

        private readonly IApiClient<RejectIntegrationExportV1Request, RejectIntegrationExportV1Response> _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RejectDownloadIntegrationExportCommandHandlerDecorator"/> class.
        /// </summary>
        /// <param name="handler">Injected command handler</param>
        /// <param name="apiClient">Injected api client</param>
        public RejectDownloadIntegrationExportCommandHandlerDecorator(
            IDownloadIntegrationExportCommandHandler handler,
            IApiClient<RejectIntegrationExportV1Request, RejectIntegrationExportV1Response> apiClient) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));
            Argument.NotNull(apiClient, nameof(apiClient));

            _handler = handler;

            _apiClient = apiClient;
        }

        /// <summary>
        /// Reject download integration export
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<DownloadIntegrationExportCommandResult> Handle(
            DownloadIntegrationExportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            if (command.Accept == true)
            {
                return _handler.Handle(command, cancellationToken);
            }
            else
            {
                return Reject(command, cancellationToken);
            }
        }

        private async Task<DownloadIntegrationExportCommandResult> Reject(
            DownloadIntegrationExportCommand command,
            CancellationToken cancellationToken)
        {
            var request = new RejectIntegrationExportV1Request
            {
                IntegrationExportId = command.IntegrationExportId,
                Message = "Not configured for this integration",
            };

            _ = await _apiClient
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            var commandResult = new DownloadIntegrationExportCommandResult
            {
                Success = false,
                Message = request.Message,
                Exception = null,
            };

            return commandResult;
        }
    }
}
