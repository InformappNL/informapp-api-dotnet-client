using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat request factory drive info interceptor
    /// </summary>
    public class HeartbeatRequestFactoryDriveInterceptor : IFactoryInterceptor<CreateIntegrationUserHeartbeatV1Request>
    {
        private readonly IFactory<HeartbeatDriveInfoReport> _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatRequestFactoryDriveInterceptor"/> class.
        /// </summary>
        public HeartbeatRequestFactoryDriveInterceptor(
            IFactory<HeartbeatDriveInfoReport> factory)
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

            result.Drives = report.Drives;
        }
    }
}
