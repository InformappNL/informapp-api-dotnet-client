using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Heartbeat request factory datasource interceptor
    /// </summary>
    public class HeartbeatRequestFactoryDataSourceInterceptor : IFactoryInterceptor<CreateIntegrationUserHeartbeatV1Request>
    {
        private readonly IFactory<HeartbeatDataSourceReport> _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatRequestFactoryDataSourceInterceptor"/> class.
        /// </summary>
        public HeartbeatRequestFactoryDataSourceInterceptor(
            IFactory<HeartbeatDataSourceReport> factory)
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

            result.DataSourceEnabled = report.DataSourceEnabled;
            result.DataSources = report.DataSources;
        }
    }
}
