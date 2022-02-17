using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat request factory integration import interceptor
    /// </summary>
    public class HeartbeatRequestFactoryIntegrationImportInterceptor : IFactoryInterceptor<CreateIntegrationUserHeartbeatV1Request>
    {
        private readonly IFactory<HeartbeatIntegrationImportReport> _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatRequestFactoryIntegrationImportInterceptor"/> class.
        /// </summary>
        public HeartbeatRequestFactoryIntegrationImportInterceptor(
            IFactory<HeartbeatIntegrationImportReport> factory)
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

            result.IntegrationImportEnabled = report.Enabled;
            result.IntegrationImports = report.IntegrationImports;
        }
    }
}
