using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using System.Collections.Generic;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat datasource report
    /// </summary>
    public class HeartbeatDataSourceReport
    {
        /// <summary>
        /// Datasource enabled
        /// </summary>
        public bool? DataSourceEnabled { get; set; }

        /// <summary>
        /// Datasources
        /// </summary>
        public IReadOnlyList<CreateIntegrationUserHeartbeatV1RequestDataSource> DataSources { get; set; }
    }
}
