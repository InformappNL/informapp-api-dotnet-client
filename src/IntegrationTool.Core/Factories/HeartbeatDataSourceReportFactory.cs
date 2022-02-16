using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat datasource report factory
    /// </summary>
    public class HeartbeatDataSourceReportFactory : IFactory<HeartbeatDataSourceReport>
    {
        private readonly IOptions<DataSourceConfiguration> _dataSourceConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatDataSourceReportFactory"/> class.
        /// </summary>
        public HeartbeatDataSourceReportFactory(
            IOptions<DataSourceConfiguration> dataSourceConfiguration)
        {
            Argument.NotNull(dataSourceConfiguration, nameof(dataSourceConfiguration));

            _dataSourceConfiguration = dataSourceConfiguration;
        }

        /// <summary>
        /// Create heartbeat datasource report.
        /// </summary>
        /// <returns>The created instance of heartbeat datasource report.</returns>
        public HeartbeatDataSourceReport Create()
        {
            var dataSourceConfiguration = _dataSourceConfiguration.Value;

            bool enabled = dataSourceConfiguration.Enabled ?? false;

            var dataSources = dataSourceConfiguration
                .DataSources
                .Where(x => x.Enabled == true)
                .Select(x => new CreateIntegrationUserHeartbeatV1RequestDataSource
                {
                    DataSourceId = x.DataSourceId,
                })
                .ToList();

            var report = new HeartbeatDataSourceReport
            {
                DataSourceEnabled = enabled,
                DataSources = dataSources,
            };

            return report;
        }
    }
}
