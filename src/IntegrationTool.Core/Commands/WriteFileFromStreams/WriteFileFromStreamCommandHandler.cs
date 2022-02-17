using ConnectedDevelopment.InformSystem.IntegrationTool.Core.IO;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Requires;
using System;
using System.IO;
using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands.WriteFileFromStreams
{
    /// <summary>
    /// Command handler for writing a file from a stream
    /// </summary>
    public class WriteFileFromStreamCommandHandler : ICommandHandler<WriteFileFromStreamCommand, WriteFileFromStreamCommandResult>
    {
        private const int BufferSize = 1024 * 16;

        private readonly IDirectoryCreator _directoryCreator;

        private readonly IPath _path;

        private readonly IFileStreamFactory _fileStreamFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="WriteFileFromStreamCommandHandler"/> class
        /// </summary>
        /// <param name="directoryCreator">Injected directory creator</param>
        /// <param name="path">Injected path</param>
        /// /// <param name="fileStreamFactory">Injected file stream factory</param>
        public WriteFileFromStreamCommandHandler(
            IDirectoryCreator directoryCreator,
            IPath path,
            IFileStreamFactory fileStreamFactory)
        {
            _directoryCreator = directoryCreator;

            _path = path;

            _fileStreamFactory = fileStreamFactory;
        }

        /// <summary>
        /// Handles writing a file from a stream
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<WriteFileFromStreamCommandResult> Handle(
            WriteFileFromStreamCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var commandResult = new WriteFileFromStreamCommandResult();

            string folderPath = command.Path;

            if (string.IsNullOrEmpty(folderPath) == false)
            {
                await _directoryCreator
                    .CreateDirectoryAsync(folderPath, cancellationToken)
                    .ConfigureAwait(Await.Default);
            }

            string filePath = _path.Combine(folderPath, command.FileName);

            byte[] buffer = new byte[BufferSize];

            long bytesWritten = 0L;

            using (var fileStream = _fileStreamFactory.Create(filePath, FileMode.Create, FileAccess.Write, FileShare.None, BufferSize, useAsync: true))
            {
                int read;

                while ((read = await command.File
                    .ReadAsync(buffer, 0, buffer.Length, cancellationToken)
                    .ConfigureAwait(Await.Default)) > 0)
                {
                    bytesWritten += read;

                    if (bytesWritten > command.Size.Value)
                    {
                        throw new InvalidOperationException("Bytes saved greater than file size.");
                    }

                    await fileStream
                        .WriteAsync(buffer, 0, read, cancellationToken)
                        .ConfigureAwait(Await.Default);
                }

                await fileStream
                    .FlushAsync(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }

            Require.MustBeTrue(bytesWritten, command.Size == bytesWritten, nameof(command.Size), "File size equals bytes saved");

            commandResult.Result = WriteFileFromStreamCommandResultKind.Success;

            commandResult.BytesWritten = bytesWritten;

            return commandResult;
        }
    }
}
