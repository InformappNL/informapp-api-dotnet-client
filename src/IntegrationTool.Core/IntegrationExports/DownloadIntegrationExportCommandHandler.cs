using Informapp.InformSystem.IntegrationTool.Core.Commands;
using Informapp.InformSystem.IntegrationTool.Core.Commands.SaveIntegrationExportFile;
using Informapp.InformSystem.IntegrationTool.Core.Enums;
using Informapp.InformSystem.IntegrationTool.Core.Requires;
using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Integrations.Exports;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationExports
{
    /// <summary>
    /// Command handler for downloading an integration export
    /// </summary>
    public class DownloadIntegrationExportCommandHandler : IDownloadIntegrationExportCommandHandler
    {
        private readonly IApiClient<DownloadIntegrationExportV1Request, DownloadIntegrationExportV1Response> _client;

        private readonly ICommandHandler<SaveIntegrationExportFileCommand, SaveIntegrationExportFileCommandResult> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadIntegrationExportCommandHandler"/> class
        /// </summary>
        /// <param name="client">Injected api client</param>
        /// <param name="handler">Injected command handler</param>
        public DownloadIntegrationExportCommandHandler(
            IApiClient<DownloadIntegrationExportV1Request, DownloadIntegrationExportV1Response> client,
            ICommandHandler<SaveIntegrationExportFileCommand, SaveIntegrationExportFileCommandResult> handler)
        {
            _client = client;

            _handler = handler;
        }

        /// <summary>
        /// Handles downloading the integration export
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<DownloadIntegrationExportCommandResult> Handle(
            DownloadIntegrationExportCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var commandResult = new DownloadIntegrationExportCommandResult();

            var configuration = command.Configuration;

            Require.NotNull(configuration, nameof(configuration));

            var request = new DownloadIntegrationExportV1Request
            {
                IntegrationExportId = command.IntegrationExportId,
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            if (response.IsSuccessful)
            {
                using (var model = response.Model)
                {
                    var saveCommand = new SaveIntegrationExportFileCommand
                    {
                        IntegrationExportId = command.IntegrationExportId,
                        File = model.File,
                        FileName = model.FileName,
                        FileSize = model.Size,
                        DestinationFolder = configuration.Folder,
                        BackupFolder = configuration.BackupFolder,
                        Overwrite = configuration.Overwrite,
                    };

                    var saveCommandResult = await _handler
                        .Handle(saveCommand, cancellationToken)
                        .ConfigureAwait(Await.Default);

                    switch (saveCommandResult.Result)
                    {
                        case SaveIntegrationExportFileCommandResultKind.Success:
                            commandResult.Success = true; // TODO: ??
                            commandResult.Message = ""; // TODO: add backup file name and size
                            break;
                        case SaveIntegrationExportFileCommandResultKind.Failed:
                            commandResult.Success = false;
                            commandResult.Message = ""; // TODO:
                            break;
                        default:
                            throw UnexpectedEnumValueException.Create(saveCommandResult.Result);
                    }
                }
            }
            else
            {
                commandResult.Success = false;
                commandResult.Message = "Error downloading integration export";
            }

            return commandResult;
        }
    }
}
