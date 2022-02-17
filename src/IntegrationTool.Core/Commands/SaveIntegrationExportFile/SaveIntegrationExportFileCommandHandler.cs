using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands.MoveFile;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands.WriteFileFromStreams;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands.SaveIntegrationExportFile
{
    /// <summary>
    /// Command handler for saving a file received from an export
    /// </summary>
    public class SaveIntegrationExportFileCommandHandler : ICommandHandler<SaveIntegrationExportFileCommand, SaveIntegrationExportFileCommandResult>
    {

        private readonly ICommandHandler<WriteFileFromStreamCommand, WriteFileFromStreamCommandResult> _writeFileHandler;

        private readonly ICommandHandler<MoveFileCommand, MoveFileCommandResult> _moveFileHandler;

        private readonly IFactory<SaveIntegrationExportFileFactoryCommand, SaveIntegrationExportFileFactoryCommandResult> _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveIntegrationExportFileCommandHandler"/> class
        /// </summary>
        /// <param name="writeFileHandler">Injected write file handler</param>
        /// <param name="moveFileHandler">Injected move file handler</param>
        /// <param name="factory">Factory for values that can be copied to the command result</param>
        public SaveIntegrationExportFileCommandHandler(
            ICommandHandler<WriteFileFromStreamCommand, WriteFileFromStreamCommandResult> writeFileHandler,
            ICommandHandler<MoveFileCommand, MoveFileCommandResult> moveFileHandler,
            IFactory<SaveIntegrationExportFileFactoryCommand, SaveIntegrationExportFileFactoryCommandResult> factory)
        {
            Argument.NotNull(writeFileHandler, nameof(writeFileHandler));
            Argument.NotNull(moveFileHandler, nameof(moveFileHandler));
            Argument.NotNull(factory, nameof(factory));

            _writeFileHandler = writeFileHandler;

            _moveFileHandler = moveFileHandler;

            _factory = factory;
        }

        /// <summary>
        /// Handles saving the file and moving it to the correct place
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<SaveIntegrationExportFileCommandResult> Handle(
            SaveIntegrationExportFileCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var commandResult = new SaveIntegrationExportFileCommandResult();

            var factoryCommand = new SaveIntegrationExportFileFactoryCommand
            {
                IntegrationExportId = command.IntegrationExportId,
                IntegrationFolder = command.DestinationFolder,
                FileName = command.FileName,
                IntegrationBackupFolder = command.BackupFolder,
            };

            var factoryResult = _factory.Create(factoryCommand);

            var writeFileCommand = new WriteFileFromStreamCommand
            {
                File = command.File,
                FileName = factoryResult.DownloadFileName,
                Path = factoryResult.DownloadFolder,
                Size = command.FileSize
            };

            var writeFileResult = await _writeFileHandler
                .Handle(writeFileCommand, cancellationToken)
                .ConfigureAwait(Await.Default);

            if (writeFileResult.Result == WriteFileFromStreamCommandResultKind.Success)
            {
                var moveFileCommand = new MoveFileCommand
                {
                    Source = factoryResult.DownloadPath,
                    Destination = factoryResult.IntegrationPath,
                    Overwrite = command.Overwrite,
                    Backup = factoryResult.BackupPath
                };

                var moveFileResult = await _moveFileHandler
                    .Handle(moveFileCommand, cancellationToken)
                    .ConfigureAwait(Await.Default);

                commandResult.FileOverwritten = moveFileResult.FileOverwritten;
                commandResult.BackupFileName = factoryResult.BackupFileName;
                commandResult.BackupFileSize = moveFileResult.BackupFileSize;
                commandResult.Result = SaveIntegrationExportFileCommandResultKind.Success;
            }
            else
            {
                commandResult.Result = SaveIntegrationExportFileCommandResultKind.Failed;
            }

            return commandResult;
        }
    }
}
