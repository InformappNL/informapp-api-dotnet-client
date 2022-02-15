using System.Collections.Generic;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    public class HeartbeatConfigurationDictionary
    {
        public HeartbeatConfigurationDictionary(
            IDictionary<string, object> configuration)
        {
            Argument.NotNull(configuration, nameof(configuration));

            Configuration = configuration;
        }

        public IDictionary<string, object> Configuration { get; }
    }
}
