using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
using ConnectedDevelopment.InformSystem.WebApi.Client.DateTimeProviders;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.IO.Abstractions;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Save integration export file factory
    /// </summary>
    public class SaveIntegrationExportFileFactory : IFactory<SaveIntegrationExportFileFactoryCommand, SaveIntegrationExportFileFactoryCommandResult>
    {
        private readonly IOptions<IntegrationExportConfiguration> _integrationConfiguration;

        private readonly IDateTimeProvider _dateTimeProvider;

        private readonly IPath _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveIntegrationExportFileFactory"/> class.
        /// </summary>
        public SaveIntegrationExportFileFactory(
            IOptions<IntegrationExportConfiguration> integrationConfiguration,
            IDateTimeProvider dateTimeProvider,
            IPath path)
        {
            Argument.NotNull(integrationConfiguration, nameof(integrationConfiguration));
            Argument.NotNull(dateTimeProvider, nameof(dateTimeProvider));
            Argument.NotNull(path, nameof(path));

            _integrationConfiguration = integrationConfiguration;

            _dateTimeProvider = dateTimeProvider;

            _path = path;

        }

        /// <summary>
        /// Creates the save integration export file factory command result
        /// </summary>
        /// <param name="command">The command</param>
        /// <returns>The save integration export file command result</returns>
        public SaveIntegrationExportFileFactoryCommandResult Create(SaveIntegrationExportFileFactoryCommand command)
        {
            Argument.NotNull(command, nameof(command));

            string fileNameWithoutExtension = _path.GetFileNameWithoutExtension(command.FileName);
            string extension = _path.GetExtension(command.FileName);

            var now = _dateTimeProvider.UtcNow;

            string downloadFileName = string.Format(
                CultureInfo.InvariantCulture,
                "{0}_{1:yyyyMMddHHmmssfff}{2}",
                command.IntegrationExportId,
                now,
                extension);

            string backupFileName = string.Format(
                CultureInfo.InvariantCulture,
                "{0}_BU_{1}_{2:yyyyMMddHHmmssfff}{3}",
                fileNameWithoutExtension,
                command.IntegrationExportId,
                now,
                extension);

            return new SaveIntegrationExportFileFactoryCommandResult
            {
                DownloadPath = _path.Combine(_integrationConfiguration.Value.DownloadFolder, downloadFileName),
                DownloadFileName = downloadFileName,
                DownloadFolder = _integrationConfiguration.Value.DownloadFolder,
                IntegrationPath = _path.Combine(command.IntegrationFolder, command.FileName),
                BackupPath = _path.Combine(command.IntegrationBackupFolder, backupFileName),
                BackupFileName = backupFileName
            };
        }
    }
}
