using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.IO.Abstractions;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands.CleanupDownloadFolder
{
    /// <summary>
    /// Command handler for cleaning up the download folder
    /// </summary>
    public class CleanupDownloadFolderCommandHandler : ICommandHandler<CleanupDownloadFolderCommand, CleanupDownloadFolderCommandResult>
    {
        private readonly IDirectoryInfoFactory _directoryInfoFactory;

        private readonly IOptions<IntegrationExportConfiguration> _integrationConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="CleanupDownloadFolderCommandHandler"/> class
        /// </summary>
        /// <param name="directoryInfoFactory">Injected directory info factory</param>
        /// <param name="integrationConfiguration">Injected configuration</param>
        public CleanupDownloadFolderCommandHandler(
            IDirectoryInfoFactory directoryInfoFactory,
            IOptions<IntegrationExportConfiguration> integrationConfiguration)
        {
            Argument.NotNull(integrationConfiguration, nameof(integrationConfiguration));
            Argument.NotNull(directoryInfoFactory, nameof(directoryInfoFactory));

            _directoryInfoFactory = directoryInfoFactory;

            _integrationConfiguration = integrationConfiguration;
        }

        /// <summary>
        /// Handles the cleanup process
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public Task<CleanupDownloadFolderCommandResult> Handle(
            CleanupDownloadFolderCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var commandResult = new CleanupDownloadFolderCommandResult();

            string downloadFolder = _integrationConfiguration.Value.DownloadFolder;

            var downloadFolderInfo = _directoryInfoFactory.FromDirectoryName(downloadFolder);

            int filesDeleted = 0;
            int filesNotDeleted = 0;

            if (downloadFolderInfo.Exists)
            {
                var files = downloadFolderInfo.EnumerateFiles();

                foreach (var file in files)
                {
                    try
                    {
                        file.Delete();

                        filesDeleted++;
                    }
                    catch (Exception e)
                    when (
                        e is IOException ||
                        e is SecurityException ||
                        e is UnauthorizedAccessException)
                    {
                        filesNotDeleted++;
                    }
                }
            }

            commandResult.Result = CleanupDownloadFolderCommandResultKind.Success;
            commandResult.FilesDeleted = filesDeleted;
            commandResult.FilesNotDeleted = filesNotDeleted;

            return Task.FromResult(commandResult);
        }
    }
}
