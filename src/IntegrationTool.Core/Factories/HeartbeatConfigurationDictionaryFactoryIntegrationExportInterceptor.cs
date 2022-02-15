using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Microsoft.Extensions.Options;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat configuration dictionary factory integration export interceptor
    /// </summary>
    public class HeartbeatConfigurationDictionaryFactoryIntegrationExportInterceptor : IFactoryInterceptor<HeartbeatConfigurationDictionary>
    {
        /// <summary>
        /// Configuration key
        /// </summary>
        public const string Key = "IntegrationExports";

        private readonly IOptions<IntegrationExportConfiguration> _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatConfigurationDictionaryFactoryIntegrationExportInterceptor"/> class.
        /// </summary>
        public HeartbeatConfigurationDictionaryFactoryIntegrationExportInterceptor(
            IOptions<IntegrationExportConfiguration> configuration)
        {
            Argument.NotNull(configuration, nameof(configuration));

            _configuration = configuration;
        }

        /// <summary>
        /// Intercept the created instance
        /// </summary>
        /// <param name="result">The created instance</param>
        public void Created(HeartbeatConfigurationDictionary result)
        {
            Argument.NotNull(result, nameof(result));

            var value = _configuration.Value;

            result.Configuration.Add(Key, value);
        }
    }
}
