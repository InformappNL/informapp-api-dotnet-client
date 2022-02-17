using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Abstractions;
using System.Linq;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat drive info factory
    /// </summary>
    public class HeartbeatDriveInfoFactory : IFactory<HeartbeatDriveInfoReport>
    {
        private readonly IDriveInfoFactory _driveInfoFactory;

        private readonly IOptions<IntegrationConfiguration> _integrationConfiguration;

        private readonly IOptions<IntegrationExportConfiguration> _integrationExportConfiguration;

        private readonly IOptions<IntegrationImportConfiguration> _integrationImportConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatDriveInfoFactory"/> class.
        /// </summary>
        public HeartbeatDriveInfoFactory(
            IDriveInfoFactory driveInfoFactory,
            IOptions<IntegrationConfiguration> integrationConfiguration,
            IOptions<IntegrationExportConfiguration> integrationExportConfiguration,
            IOptions<IntegrationImportConfiguration> integrationImportConfiguration)
        {
            Argument.NotNull(driveInfoFactory, nameof(driveInfoFactory));
            Argument.NotNull(integrationConfiguration, nameof(integrationConfiguration));
            Argument.NotNull(integrationExportConfiguration, nameof(integrationExportConfiguration));
            Argument.NotNull(integrationImportConfiguration, nameof(integrationImportConfiguration));

            _driveInfoFactory = driveInfoFactory;

            _integrationConfiguration = integrationConfiguration;

            _integrationExportConfiguration = integrationExportConfiguration;

            _integrationImportConfiguration = integrationImportConfiguration;
        }

        /// <summary>
        /// Create heartbeat drive info report.
        /// </summary>
        /// <returns>The created instance of heartbeat drive info report.</returns>
        public HeartbeatDriveInfoReport Create()
        {
            var report = new HeartbeatDriveInfoReport();

            var configuration = _integrationConfiguration.Value;

            if (configuration.DriveInfoUploadEnabled == true)
            {
                var paths = new List<string>();

                AddIntegrationExportFolders(paths);
                AddIntegrationExportDefaultFolder(paths);
                AddIntegrationImportFiles(paths);

                var comparer = StringComparer.Ordinal;

                var drives = paths
                    .Where(x => string.IsNullOrEmpty(x) == false)
                    .Distinct(comparer)
                    .OrderBy(x => x, comparer)
                    .Select(x => CreateDriveInfo(x))
                    .Where(x => x != null)
                    .GroupBy(x => x.Name, comparer)
                    .Select(x => x.First())
                    .Select(x => new CreateIntegrationUserHeartbeatV1RequestDrive
                    {
                        Path = x.Name,
                        AvailableFreeSpace = x.AvailableFreeSpace,
                        TotalFreeSpace = x.TotalFreeSpace,
                        TotalSize = x.TotalSize,
                    })
                    .ToList();

                report.Drives = drives;
            }

            return report;
        }

        private void AddIntegrationExportFolders(List<string> paths)
        {
            var configuration = _integrationExportConfiguration.Value;

            var folders = configuration
                .IntegrationExports
                .Where(x => x.Enabled == true)
                .Select(x => x.Folder)
                .ToList();

            paths.AddRange(folders);
        }

        private void AddIntegrationExportDefaultFolder(List<string> paths)
        {
            var configuration = _integrationExportConfiguration.Value;

            if (configuration.Default != null &&
                configuration.Default.Enabled == true)
            {
                paths.Add(configuration.Default.Folder);
            }
        }

        private void AddIntegrationImportFiles(List<string> paths)
        {
            var configuration = _integrationImportConfiguration.Value;

            var files = configuration
                .IntegrationImports
                .Where(x => x.Enabled == true)
                .Select(x => x.File)
                .ToList();

            paths.AddRange(files);
        }

        [DebuggerStepThrough]
        private IDriveInfo CreateDriveInfo(string driveName)
        {
            IDriveInfo driveInfo;

            if (string.IsNullOrEmpty(driveName))
            {
                driveInfo = null;
            }
            else
            {
                try
                {
                    driveInfo = _driveInfoFactory.FromDriveName(driveName);
                }
                catch (ArgumentException)
                {
                    driveInfo = null;
                }
            }

            return driveInfo;
        }
    }
}
