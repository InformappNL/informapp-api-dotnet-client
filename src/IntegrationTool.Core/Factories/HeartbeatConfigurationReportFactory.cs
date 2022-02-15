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
        private readonly IOptions<DataContextConfiguration> _dataContextConfiguration;

        private readonly IOptions<DataSourceConfiguration> _dataSourceConfiguration;

        private readonly IOptions<IntegrationConfiguration> _integrationConfiguration;

        private readonly IOptions<IntegrationExportConfiguration> _integrationExportConfiguration;

        private readonly IOptions<IntegrationImportConfiguration> _integrationImportConfiguration;

        private readonly IOptions<CleanupFolderConfiguration> _cleanupFolderConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatConfigurationReportFactory"/> class.
        /// </summary>
        public HeartbeatConfigurationReportFactory(
            IOptions<DataContextConfiguration> dataContextConfiguration,
            IOptions<DataSourceConfiguration> dataSourceConfiguration,
            IOptions<IntegrationConfiguration> integrationConfiguration,
            IOptions<IntegrationExportConfiguration> integrationExportConfiguration,
            IOptions<IntegrationImportConfiguration> integrationImportConfiguration,
            IOptions<CleanupFolderConfiguration> cleanupFolderConfiguration)
        {
            Argument.NotNull(dataContextConfiguration, nameof(dataContextConfiguration));
            Argument.NotNull(dataSourceConfiguration, nameof(dataSourceConfiguration));
            Argument.NotNull(integrationConfiguration, nameof(integrationConfiguration));
            Argument.NotNull(integrationExportConfiguration, nameof(integrationExportConfiguration));
            Argument.NotNull(integrationImportConfiguration, nameof(integrationImportConfiguration));
            Argument.NotNull(cleanupFolderConfiguration, nameof(cleanupFolderConfiguration));

            _dataContextConfiguration = dataContextConfiguration;

            _dataSourceConfiguration = dataSourceConfiguration;

            _integrationConfiguration = integrationConfiguration;

            _integrationExportConfiguration = integrationExportConfiguration;

            _integrationImportConfiguration = integrationImportConfiguration;

            _cleanupFolderConfiguration = cleanupFolderConfiguration;
        }

        /// <summary>
        /// Create heartbeat configuration report.
        /// </summary>
        /// <returns>The created instance of heartbeat configuration report.</returns>
        public HeartbeatConfigurationReport Create()
        {
            var dataContextConfiguration = _dataContextConfiguration.Value;

            var dataSourceConfiguration = _dataSourceConfiguration.Value;

            var integrationConfiguration = _integrationConfiguration.Value;

            var integrationExportConfiguration = _integrationExportConfiguration.Value;

            var integrationImportConfiguration = _integrationImportConfiguration.Value;

            var cleanupFolderConfiguration = _cleanupFolderConfiguration.Value;

            var configurationReport = new
            {
                DataContext = dataContextConfiguration,
                DataSources = dataSourceConfiguration,
                Integrations = integrationConfiguration,
                IntegrationExports = integrationExportConfiguration,
                IntegrationImports = integrationImportConfiguration,
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
