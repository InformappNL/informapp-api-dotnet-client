using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
using Microsoft.Extensions.Options;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heatbeat configuration dictionary factory cleanup folder interceptor
    /// </summary>
    public class HeartbeatConfigurationDictionaryFactoryCleanupFolderInterceptor : IFactoryInterceptor<HeartbeatConfigurationDictionary>
    {
        /// <summary>
        /// Configuration key
        /// </summary>
        public const string Key = "CleanupFolder";

        private readonly IOptions<CleanupFolderConfiguration> _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatConfigurationDictionaryFactoryCleanupFolderInterceptor"/> class.
        /// </summary>
        public HeartbeatConfigurationDictionaryFactoryCleanupFolderInterceptor(
            IOptions<CleanupFolderConfiguration> configuration)
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
