using System;
using System.Collections.Generic;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat configuration dictionary factory
    /// </summary>
    public class HeartbeatConfigurationDictionaryFactory : IFactory<HeartbeatConfigurationDictionary>
    {
        /// <summary>
        /// Create instance
        /// </summary>
        public HeartbeatConfigurationDictionary Create()
        {
            var configuration = new Dictionary<string, object>(StringComparer.Ordinal);

            var dictionary = new HeartbeatConfigurationDictionary(configuration);

            return dictionary;
        }
    }
}
