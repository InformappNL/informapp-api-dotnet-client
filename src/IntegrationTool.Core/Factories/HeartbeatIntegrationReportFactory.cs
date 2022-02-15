using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat integration report factory
    /// </summary>
    public class HeartbeatIntegrationReportFactory : IFactory<HeartbeatIntegrationReport>
    {
        private readonly IOptions<IntegrationConfiguration> _integrationConfiguration;

        private readonly IOptions<IntegrationExportConfiguration> _integrationExportConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatIntegrationReportFactory"/> class.
        /// </summary>
        public HeartbeatIntegrationReportFactory(
            IOptions<IntegrationConfiguration> integrationConfiguration,
            IOptions<IntegrationExportConfiguration> integrationExportConfiguration)
        {
            Argument.NotNull(integrationConfiguration, nameof(integrationConfiguration));
            Argument.NotNull(integrationExportConfiguration, nameof(integrationExportConfiguration));

            _integrationConfiguration = integrationConfiguration;

            _integrationExportConfiguration = integrationExportConfiguration;
        }

        /// <summary>
        /// Create heartbeat integration report.
        /// </summary>
        /// <returns>The created instance of heartbeat integration report.</returns>
        public HeartbeatIntegrationReport Create()
        {
            var integrationConfiguration = _integrationConfiguration.Value;
            var integrationExportConfiguration = _integrationExportConfiguration.Value;

            bool enabled = integrationConfiguration.Enabled ?? false;

            bool defaultEnabled = integrationExportConfiguration.Default?.Enabled ?? false;

            var integrations = integrationExportConfiguration
                .IntegrationExports
                .Where(x => x.Enabled == true)
                .Select(x => new CreateIntegrationUserHeartbeatV1RequestIntegration
                {
                    IntegrationId = x.IntegrationId,
                })
                .ToList();

            var report = new HeartbeatIntegrationReport
            {
                IntegrationEnabled = enabled,
                IntegrationDefaultEnabled = defaultEnabled,
                Integrations = integrations,
            };

            return report;
        }
    }
}
