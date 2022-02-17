using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat request factory integration export interceptor
    /// </summary>
    public class HeartbeatRequestFactoryIntegrationExportInterceptor : IFactoryInterceptor<CreateIntegrationUserHeartbeatV1Request>
    {
        private readonly IFactory<HeartbeatIntegrationExportReport> _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatRequestFactoryIntegrationExportInterceptor"/> class.
        /// </summary>
        public HeartbeatRequestFactoryIntegrationExportInterceptor(
            IFactory<HeartbeatIntegrationExportReport> factory)
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

            result.IntegrationEnabled = report.Enabled;
            result.IntegrationDefaultEnabled = report.DefaultEnabled;
            result.Integrations = report.IntegrationExports;
        }
    }
}
