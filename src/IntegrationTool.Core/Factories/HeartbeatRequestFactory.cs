using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Factory for creating a heartbeat request
    /// </summary>
    public class HeartbeatRequestFactory : IFactory<CreateIntegrationUserHeartbeatV1Request>
    {
        private readonly IFactory<HeartbeatConfigurationReport> _configurationFactory;

        private readonly IFactory<HeartbeatDriveInfoReport> _driveFactory;

        private readonly IFactory<HeartbeatDataSourceReport> _dataSourceFactory;

        private readonly IFactory<HeartbeatIntegrationExportReport> _integrationExportFactory;

        private readonly IFactory<HeartbeatIntegrationImportReport> _integrationImportFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatRequestFactory"/> class.
        /// </summary>
        /// <param name="configurationFactory">The configuration report factory</param>
        /// <param name="driveFactory">The drive report factory</param>
        /// <param name="dataSourceFactory">The datasource report factory</param>
        /// <param name="integrationExportFactory">The integration export report factory</param>
        /// <param name="integrationImportFactory">The integration import report factory</param>
        public HeartbeatRequestFactory(
            IFactory<HeartbeatConfigurationReport> configurationFactory,
            IFactory<HeartbeatDriveInfoReport> driveFactory,
            IFactory<HeartbeatDataSourceReport> dataSourceFactory,
            IFactory<HeartbeatIntegrationExportReport> integrationExportFactory,
            IFactory<HeartbeatIntegrationImportReport> integrationImportFactory)
        {
            Argument.NotNull(configurationFactory, nameof(configurationFactory));
            Argument.NotNull(driveFactory, nameof(driveFactory));
            Argument.NotNull(dataSourceFactory, nameof(dataSourceFactory));
            Argument.NotNull(integrationExportFactory, nameof(integrationExportFactory));
            Argument.NotNull(integrationImportFactory, nameof(integrationImportFactory));

            _configurationFactory = configurationFactory;

            _driveFactory = driveFactory;

            _dataSourceFactory = dataSourceFactory;

            _integrationExportFactory = integrationExportFactory;

            _integrationImportFactory = integrationImportFactory;
        }

        /// <summary>
        /// Creates the heartbeat request
        /// </summary>
        /// <returns>The heartbeat request</returns>
        public CreateIntegrationUserHeartbeatV1Request Create()
        {
            var configurationReport = _configurationFactory.Create();

            string version = VersionConstants.Version;

            var driveReport = _driveFactory.Create();

            var dataSourceReport = _dataSourceFactory.Create();

            var integrationExportReport = _integrationExportFactory.Create();

            var integrationImportReport = _integrationImportFactory.Create();

            var request = new CreateIntegrationUserHeartbeatV1Request
            {
                Configuration = configurationReport.Configuration,

                Version = version,

                Drives = driveReport.Drives,

                DataSourceEnabled = dataSourceReport.DataSourceEnabled,
                DataSources = dataSourceReport.DataSources,

                IntegrationEnabled = integrationExportReport.Enabled,
                IntegrationDefaultEnabled = integrationExportReport.DefaultEnabled,
                Integrations = integrationExportReport.IntegrationExports,

                IntegrationImportEnabled = integrationImportReport.Enabled,
                IntegrationImports = integrationImportReport.IntegrationImports,
            };

            return request;
        }
    }
}
