using System.Collections.Generic;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat configuration dictionary
    /// </summary>
    public class HeartbeatConfigurationDictionary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatConfigurationDictionary"/> class.
        /// </summary>
        public HeartbeatConfigurationDictionary(
            IDictionary<string, object> configuration)
        {
            Argument.NotNull(configuration, nameof(configuration));

            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IDictionary<string, object> Configuration { get; }
    }
}
