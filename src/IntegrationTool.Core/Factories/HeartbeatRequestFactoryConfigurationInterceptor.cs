using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat request factory configuration interceptor
    /// </summary>
    public class HeartbeatRequestFactoryConfigurationInterceptor : IFactoryInterceptor<CreateIntegrationUserHeartbeatV1Request>
    {
        private readonly IFactory<HeartbeatConfigurationReport> _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatRequestFactoryConfigurationInterceptor"/> class.
        /// </summary>
        public HeartbeatRequestFactoryConfigurationInterceptor(
            IFactory<HeartbeatConfigurationReport> factory)
        {
            Argument.NotNull(factory, nameof(factory));

            _factory = factory;
        }

        /// <summary>
        /// Intercept the created instance
        /// </summary>
        /// <param name="result">The created instance</param>
        public void Created(CreateIntegrationUserHeartbeatV1Request result)
        {
            Argument.NotNull(result, nameof(result));

            var report = _factory.Create();

            result.Configuration = report.Configuration;
        }
    }
}
