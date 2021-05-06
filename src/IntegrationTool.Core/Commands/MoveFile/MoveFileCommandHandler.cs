using Informapp.InformSystem.IntegrationTool.Core.IO;
using Informapp.InformSystem.IntegrationTool.Core.Requires;
using System.IO;
using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands.MoveFile
{
    /// <summary>
    /// Command handler for moving a file
    /// </summary>
    public class MoveFileCommandHandler : ICommandHandler<MoveFileCommand, MoveFileCommandResult>
    {
        private readonly IDirectoryCreator _directoryCreator;

        private readonly IFileInfoFactory _fileInfoFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveFileCommandHandler"/> class
        /// </summary>
        /// <param name="directoryCreator">Injected directory creator</param>
        /// <param name="fileInfoFactory">Injected file info factory</param>
        public MoveFileCommandHandler(
            IDirectoryCreator directoryCreator,
            IFileInfoFactory fileInfoFactory)
        {
            _directoryCreator = directoryCreator;

            _fileInfoFactory = fileInfoFactory;
        }

        /// <summary>
        /// Handles the moving of the file
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<MoveFileCommandResult> Handle(
            MoveFileCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var commandResult = new MoveFileCommandResult();

            string source = command.Source;
            string destination = command.Destination;
            string backup = command.Backup;

            var fileInfoSource = _fileInfoFactory.FromFileName(source);

            if (fileInfoSource.Exists)
            {
                var fileInfoDestination = _fileInfoFactory.FromFileName(destination);
                var directoryInfoDestination = fileInfoDestination.Directory;

                if (directoryInfoDestination.Exists)
                {
                    if (fileInfoDestination.Exists)
                    {
                        if (command.Overwrite == true)
                        {
                            Require.NotNullOrEmpty(backup, nameof(backup));

                            commandResult.BackupFileSize = fileInfoDestination.Length;

                            var fileInfoBackup = _fileInfoFactory.FromFileName(backup);

                            await _directoryCreator
                                .CreateDirectoryAsync(fileInfoBackup.DirectoryName, cancellationToken)
                                .ConfigureAwait(Await.Default);

                            _ = fileInfoSource.Replace(destination, backup);

                            fileInfoSource.Delete();

                            commandResult.FileOverwritten = true;
                        }
                        else
                        {
                            throw new IOException("File already exists and overwrite is set to false.");
                        }
                    }
                    else
                    {
                        fileInfoSource.MoveTo(destination);
                    }
                }
                else
                {
                    await _directoryCreator
                        .CreateDirectoryAsync(directoryInfoDestination.FullName, cancellationToken)
                        .ConfigureAwait(Await.Default);

                    fileInfoSource.MoveTo(destination);
                }
            }
            else
            {
                throw new FileNotFoundException("Source file does not exist.", fileInfoSource.FullName);
            }

            commandResult.Result = MoveFileCommandResultKind.Success;

            return commandResult;
        }
    }
}
