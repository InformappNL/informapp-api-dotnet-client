using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries.CreateStreamFromPath;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Command handler for uploading an integration import
    /// </summary>
    public class UploadIntegrationImportCommandHandler : IUploadIntegrationImportCommandHandler
    {
        private readonly IApiClient<UploadIntegrationImportV1Request, UploadIntegrationImportV1Response> _client;

        private readonly IQueryHandler<CreateStreamFromPathQuery, CreateStreamFromPathQueryResult> _queryHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadIntegrationImportCommandHandler"/> class
        /// </summary>
        /// <param name="client">Injected api client</param>
        /// <param name="queryHandler">Injected query handler</param>
        public UploadIntegrationImportCommandHandler(
            IApiClient<UploadIntegrationImportV1Request, UploadIntegrationImportV1Response> client,
            IQueryHandler<CreateStreamFromPathQuery, CreateStreamFromPathQueryResult> queryHandler)
        {
            Argument.NotNull(client, nameof(client));
            Argument.NotNull(queryHandler, nameof(queryHandler));

            _client = client;

            _queryHandler = queryHandler;
        }

        /// <summary>
        /// Handles uploading the integration import
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<UploadIntegrationImportCommandResult> Handle(
            UploadIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var commandResult = new UploadIntegrationImportCommandResult();

            var integrationImport = command.Item;

            Require.NotNull(integrationImport, nameof(integrationImport));

            var query = new CreateStreamFromPathQuery
            {
                Path = integrationImport.File
            };

            using (var queryResult = await _queryHandler
                .Handle(query, cancellationToken)
                .ConfigureAwait(Await.Default))
            {
                var uploadRequest = new UploadIntegrationImportV1Request
                {
                    IntegrationImportId = command.IntegrationImportId,
                    File = queryResult.File,
                    FileName = integrationImport.FileName,
                    Size = queryResult.Size,
                };

                var response = await _client
                    .Execute(uploadRequest, cancellationToken)
                    .ConfigureAwait(Await.Default);

                if (response.IsSuccessful)
                {
                    commandResult.Success = true;
                    commandResult.Message = "";
                    uploadRequest.Dispose();
                }
                else
                {
                    commandResult.Success = false;
                    commandResult.Message = "Error uploading integration import";
                    uploadRequest.Dispose();
                }
            }

            return commandResult;
        }
    }
}
