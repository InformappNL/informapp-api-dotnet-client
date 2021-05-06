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

        private readonly IFactory<HeartbeatIntegrationReport> _integrationFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatRequestFactory"/> class.
        /// </summary>
        /// <param name="configurationFactory">The configuration report factory</param>
        /// <param name="driveFactory">The drive report factory</param>
        /// <param name="dataSourceFactory">The datasource report factory</param>
        /// <param name="integrationFactory">The integration report factory</param>
        public HeartbeatRequestFactory(
            IFactory<HeartbeatConfigurationReport> configurationFactory,
            IFactory<HeartbeatDriveInfoReport> driveFactory,
            IFactory<HeartbeatDataSourceReport> dataSourceFactory,
            IFactory<HeartbeatIntegrationReport> integrationFactory)
        {
            Argument.NotNull(configurationFactory, nameof(configurationFactory));
            Argument.NotNull(driveFactory, nameof(driveFactory));
            Argument.NotNull(dataSourceFactory, nameof(dataSourceFactory));
            Argument.NotNull(integrationFactory, nameof(integrationFactory));

            _configurationFactory = configurationFactory;

            _driveFactory = driveFactory;

            _dataSourceFactory = dataSourceFactory;

            _integrationFactory = integrationFactory;
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

            var integrationReport = _integrationFactory.Create();

            var request = new CreateIntegrationUserHeartbeatV1Request
            {
                Configuration = configurationReport.Configuration,

                Version = version,

                Drives = driveReport.Drives,

                DataSourceEnabled = dataSourceReport.DataSourceEnabled,
                DataSources = dataSourceReport.DataSources,

                IntegrationEnabled = integrationReport.IntegrationEnabled,
                IntegrationDefaultEnabled = integrationReport.IntegrationDefaultEnabled,
                Integrations = integrationReport.Integrations,
            };

            return request;
        }
    }
}
