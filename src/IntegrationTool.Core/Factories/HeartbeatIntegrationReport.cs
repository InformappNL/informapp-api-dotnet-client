using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using System.Collections.Generic;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat integration report
    /// </summary>
    public class HeartbeatIntegrationReport
    {
        /// <summary>
        /// Integration enabled
        /// </summary>
        public bool? IntegrationEnabled { get; set; }

        /// <summary>
        /// Integration default enabled
        /// </summary>
        public bool? IntegrationDefaultEnabled { get; set; }

        /// <summary>
        /// Integrations
        /// </summary>
        public IReadOnlyList<CreateIntegrationUserHeartbeatV1RequestIntegration> Integrations { get; set; }
    }
}
