using Newtonsoft.Json;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat configuration report factory
    /// </summary>
    public class HeartbeatConfigurationReportFactory : IFactory<HeartbeatConfigurationReport>
    {
        private readonly IFactory<HeartbeatConfigurationDictionary> _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatConfigurationReportFactory"/> class.
        /// </summary>
        public HeartbeatConfigurationReportFactory(
            IFactory<HeartbeatConfigurationDictionary> factory)
        {
            Argument.NotNull(factory, nameof(factory));

            _factory = factory;
        }

        /// <summary>
        /// Create heartbeat configuration report.
        /// </summary>
        /// <returns>The created instance of heartbeat configuration report.</returns>
        public HeartbeatConfigurationReport Create()
        {
            var dictionary = _factory.Create();

            string configuration = JsonConvert.SerializeObject(dictionary.Configuration, Formatting.Indented);

            var report = new HeartbeatConfigurationReport
            {
                Configuration = configuration,
            };

            return report;
        }
    }
}
