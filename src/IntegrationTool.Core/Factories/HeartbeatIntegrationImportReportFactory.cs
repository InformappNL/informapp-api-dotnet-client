using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using Microsoft.Extensions.Options;
using System.Linq;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat integration import factory
    /// </summary>
    public class HeartbeatIntegrationImportReportFactory : IFactory<HeartbeatIntegrationImportReport>
    {
        private readonly IOptions<IntegrationImportConfiguration> _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatIntegrationImportReportFactory"/> class.
        /// </summary>
        public HeartbeatIntegrationImportReportFactory(
            IOptions<IntegrationImportConfiguration> configuration)
        {
            Argument.NotNull(configuration, nameof(configuration));

            _configuration = configuration;
        }

        /// <summary>
        /// Create heartbeat integration import report.
        /// </summary>
        /// <returns>The created instance of heartbeat integration import report.</returns>
        public HeartbeatIntegrationImportReport Create()
        {
            var configuration = _configuration.Value;

            bool enabled = configuration.Enabled ?? false;

            var integrationImports = configuration
                .IntegrationImports
                .Where(x => x.Enabled == true)
                .Select(x => new CreateIntegrationUserHeartbeatV1RequestIntegrationImport
                {
                    IntegrationId = x.IntegrationId,
                })
                .ToList();

            var report = new HeartbeatIntegrationImportReport
            {
                Enabled = enabled,
                IntegrationImports = integrationImports,
            };

            return report;
        }
    }
}
