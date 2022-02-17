﻿using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Configurations;
using Microsoft.Extensions.Options;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat configuration dictionary factory datacontext interceptor
    /// </summary>
    public class HeartbeatConfigurationDictionaryFactoryDataContextInterceptor : IFactoryInterceptor<HeartbeatConfigurationDictionary>
    {
        /// <summary>
        /// Configuration key
        /// </summary>
        public const string Key = "DataContext";

        private readonly IOptions<DataContextConfiguration> _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatConfigurationDictionaryFactoryCleanupFolderInterceptor"/> class.
        /// </summary>
        public HeartbeatConfigurationDictionaryFactoryDataContextInterceptor(
            IOptions<DataContextConfiguration> configuration)
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
