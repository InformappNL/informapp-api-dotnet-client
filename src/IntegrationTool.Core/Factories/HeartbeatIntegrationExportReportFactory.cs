using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using Microsoft.Extensions.Options;
using System.Linq;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat integration export report factory
    /// </summary>
    public class HeartbeatIntegrationExportReportFactory : IFactory<HeartbeatIntegrationExportReport>
    {
        private readonly IOptions<IntegrationExportConfiguration> _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatIntegrationExportReportFactory"/> class.
        /// </summary>
        public HeartbeatIntegrationExportReportFactory(
            IOptions<IntegrationExportConfiguration> configuration)
        {
            Argument.NotNull(configuration, nameof(configuration));

            _configuration = configuration;
        }

        /// <summary>
        /// Create heartbeat integration export report.
        /// </summary>
        /// <returns>The created instance of heartbeat integration export report.</returns>
        public HeartbeatIntegrationExportReport Create()
        {
            var configuration = _configuration.Value;

            bool enabled = configuration.Enabled ?? false;

            bool defaultEnabled = configuration.Default?.Enabled ?? false;

            var integrationExports = configuration
                .IntegrationExports
                .Where(x => x.Enabled == true)
                .Select(x => new CreateIntegrationUserHeartbeatV1RequestIntegration
                {
                    IntegrationId = x.IntegrationId,
                })
                .ToList();

            var report = new HeartbeatIntegrationExportReport
            {
                Enabled = enabled,
                DefaultEnabled = defaultEnabled,
                IntegrationExports = integrationExports,
            };

            return report;
        }
    }
}
