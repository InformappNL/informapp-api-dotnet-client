using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat configuration report factory
    /// </summary>
    public class HeartbeatConfigurationReportFactory : IFactory<HeartbeatConfigurationReport>
    {
        private readonly IOptions<DataSourceConfiguration> _dataSourceConfiguration;

        private readonly IOptions<IntegrationConfiguration> _integrationConfiguration;

        private readonly IOptions<CleanupFolderConfiguration> _cleanupFolderConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatConfigurationReportFactory"/> class.
        /// </summary>
        public HeartbeatConfigurationReportFactory(
            IOptions<DataSourceConfiguration> dataSourceConfiguration,
            IOptions<IntegrationConfiguration> integrationConfiguration,
            IOptions<CleanupFolderConfiguration> cleanupFolderConfiguration)
        {
            Argument.NotNull(dataSourceConfiguration, nameof(dataSourceConfiguration));
            Argument.NotNull(integrationConfiguration, nameof(integrationConfiguration));
            Argument.NotNull(cleanupFolderConfiguration, nameof(cleanupFolderConfiguration));

            _dataSourceConfiguration = dataSourceConfiguration;

            _integrationConfiguration = integrationConfiguration;

            _cleanupFolderConfiguration = cleanupFolderConfiguration;
        }

        /// <summary>
        /// Create heartbeat configuration report.
        /// </summary>
        /// <returns>The created instance of heartbeat configuration report.</returns>
        public HeartbeatConfigurationReport Create()
        {
            var dataSourceConfiguration = _dataSourceConfiguration.Value;

            var integrationConfiguration = _integrationConfiguration.Value;

            var cleanupFolderConfiguration = _cleanupFolderConfiguration.Value;

            var configurationReport = new
            {
                DataSources = dataSourceConfiguration,
                Integrations = integrationConfiguration,
                CleanupFolder = cleanupFolderConfiguration,
            };

            var configuration = JsonConvert.SerializeObject(configurationReport, Formatting.Indented);

            var report = new HeartbeatConfigurationReport
            {
                Configuration = configuration,
            };

            return report;
        }
    }
}
