using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.IO.Abstractions;
using System.Linq;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat drive info factory
    /// </summary>
    public class HeartbeatDriveInfoFactory : IFactory<HeartbeatDriveInfoReport>
    {
        private readonly IDriveInfoFactory _driveInfoFactory;

        private readonly IOptions<IntegrationConfiguration> _integrationConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatDriveInfoFactory"/> class.
        /// </summary>
        public HeartbeatDriveInfoFactory(
            IDriveInfoFactory driveInfoFactory,
            IOptions<IntegrationConfiguration> integrationConfiguration)
        {
            Argument.NotNull(driveInfoFactory, nameof(driveInfoFactory));
            Argument.NotNull(integrationConfiguration, nameof(integrationConfiguration));

            _driveInfoFactory = driveInfoFactory;

            _integrationConfiguration = integrationConfiguration;
        }

        /// <summary>
        /// Create heartbeat drive info report.
        /// </summary>
        /// <returns>The created instance of heartbeat drive info report.</returns>
        public HeartbeatDriveInfoReport Create()
        {
            var report = new HeartbeatDriveInfoReport();

            var integrationConfiguration = _integrationConfiguration.Value;

            if (integrationConfiguration.DriveInfoUploadEnabled == true)
            {
                var folders = integrationConfiguration
                    .Integrations
                    .Where(x => x.Enabled == true)
                    .Select(x => x.Folder)
                    .ToList();

                if (integrationConfiguration.Default != null &&
                    integrationConfiguration.Default.Enabled == true)
                {
                    folders.Add(integrationConfiguration.Default.Folder);
                }

                var comparer = StringComparer.Ordinal;

                var drives = folders
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
