using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Imports;
using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Decorator class for <see cref="IUploadIntegrationImportCommandHandler"/> to start an upload
    /// </summary>
    public class StartUploadIntegrationImportDecorator : Decorator<IUploadIntegrationImportCommandHandler>,
        IUploadIntegrationImportCommandHandler
    {
        private readonly IUploadIntegrationImportCommandHandler _handler;

        private readonly IApiClient<StartIntegrationImportV1Request, StartIntegrationImportV1Response> _client;

        private readonly IFileInfoFactory _fileInfoFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartUploadIntegrationImportDecorator"/> class
        /// </summary>
        /// <param name="handler">Injected command handler</param>
        /// <param name="client">Injected client</param>
        /// <param name="fileInfoFactory">Injected file info factory</param>
        public StartUploadIntegrationImportDecorator(
            IUploadIntegrationImportCommandHandler handler,
            IApiClient<StartIntegrationImportV1Request, StartIntegrationImportV1Response> client,
            IFileInfoFactory fileInfoFactory) : base(handler)
        {
            _handler = handler;

            _client = client;

            _fileInfoFactory = fileInfoFactory;
        }

        /// <summary>
        /// Start an integration import upload
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<UploadIntegrationImportCommandResult> Handle(
            UploadIntegrationImportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            UploadIntegrationImportCommandResult commandResult;

            var integrationImport = command.Item;

            Require.NotNull(integrationImport, nameof(integrationImport));

            var fileInfo = _fileInfoFactory.FromFileName(integrationImport.File);

            var remoteImportId = integrationImport.FileVersionId;

            var request = new StartIntegrationImportV1Request
            {
                IntegrationId = integrationImport.IntegrationId,
                FileName = fileInfo.Name,
                FileDate = integrationImport.FileDate,
                FileSize = fileInfo.Length,
                FileVersionId = remoteImportId
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            if (response.IsSuccessful)
            {
                command.IntegrationImportId = response.Model.IntegrationImportId;

                commandResult = await _handler
                    .Handle(command, cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
            else
            {
                commandResult = new UploadIntegrationImportCommandResult
                {
                    Success = false,
                    Message = "Error starting integration import",
                };
            }

            return commandResult;
        }
    }
}
