using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using System;
using System.Collections.Generic;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat integration import report
    /// </summary>
    public class HeartbeatIntegrationImportReport
    {
        /// <summary>
        /// Integration import enabled
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Integration imports
        /// </summary>
        public IReadOnlyList<CreateIntegrationUserHeartbeatV1RequestIntegrationImport> IntegrationImports { get; set; }
            = Array.Empty<CreateIntegrationUserHeartbeatV1RequestIntegrationImport>();
    }
}
