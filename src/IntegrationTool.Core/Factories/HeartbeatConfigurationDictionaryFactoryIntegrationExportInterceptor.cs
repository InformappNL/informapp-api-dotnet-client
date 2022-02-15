using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Microsoft.Extensions.Options;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    public class HeartbeatConfigurationDictionaryFactoryIntegrationExportInterceptor : IFactoryInterceptor<HeartbeatConfigurationDictionary>
    {
        public const string Key = "IntegrationExports";

        private readonly IOptions<IntegrationExportConfiguration> _configuration;

        public HeartbeatConfigurationDictionaryFactoryIntegrationExportInterceptor(
            IOptions<IntegrationExportConfiguration> configuration)
        {
            Argument.NotNull(configuration, nameof(configuration));

            _configuration = configuration;
        }

        public void Created(HeartbeatConfigurationDictionary result)
        {
            Argument.NotNull(result, nameof(result));

            var value = _configuration.Value;

            result.Configuration.Add(Key, value);
        }
    }
}
