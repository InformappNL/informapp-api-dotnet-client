using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using System;
using System.Collections.Generic;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat drive info report
    /// </summary>
    public class HeartbeatDriveInfoReport
    {
        /// <summary>
        /// Drives
        /// </summary>
        public IReadOnlyList<CreateIntegrationUserHeartbeatV1RequestDrive> Drives { get; set; }
            = Array.Empty<CreateIntegrationUserHeartbeatV1RequestDrive>();
    }
}
