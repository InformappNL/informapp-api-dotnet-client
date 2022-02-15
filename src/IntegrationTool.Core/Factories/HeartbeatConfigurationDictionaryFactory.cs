using System;
using System.Collections.Generic;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    public class HeartbeatConfigurationDictionaryFactory : IFactory<HeartbeatConfigurationDictionary>
    {
        public HeartbeatConfigurationDictionary Create()
        {
            var configuration = new Dictionary<string, object>(StringComparer.Ordinal);

            var dictionary = new HeartbeatConfigurationDictionary(configuration);

            return dictionary;
        }
    }
}
