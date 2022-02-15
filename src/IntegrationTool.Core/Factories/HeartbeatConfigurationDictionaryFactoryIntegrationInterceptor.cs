using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Microsoft.Extensions.Options;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat configuration dictionary factory integration interceptor
    /// </summary>
    public class HeartbeatConfigurationDictionaryFactoryIntegrationInterceptor : IFactoryInterceptor<HeartbeatConfigurationDictionary>
    {
        /// <summary>
        /// Configuration key
        /// </summary>
        public const string Key = "Integrations";

        private readonly IOptions<IntegrationConfiguration> _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatConfigurationDictionaryFactoryIntegrationInterceptor"/> class.
        /// </summary>
        public HeartbeatConfigurationDictionaryFactoryIntegrationInterceptor(
            IOptions<IntegrationConfiguration> configuration)
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
