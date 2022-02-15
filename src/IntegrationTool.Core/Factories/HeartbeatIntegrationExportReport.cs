using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using System;
using System.Collections.Generic;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat integration export report
    /// </summary>
    public class HeartbeatIntegrationExportReport
    {
        /// <summary>
        /// Integration export enabled
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Integration export default enabled
        /// </summary>
        public bool? DefaultEnabled { get; set; }

        /// <summary>
        /// Integration exports
        /// </summary>
        public IReadOnlyList<CreateIntegrationUserHeartbeatV1RequestIntegration> IntegrationExports { get; set; }
            = Array.Empty<CreateIntegrationUserHeartbeatV1RequestIntegration>();
    }
}
