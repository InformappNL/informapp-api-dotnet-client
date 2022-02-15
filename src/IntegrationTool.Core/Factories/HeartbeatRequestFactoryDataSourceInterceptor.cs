using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    public class HeartbeatRequestFactoryDataSourceInterceptor : IFactoryInterceptor<CreateIntegrationUserHeartbeatV1Request>
    {
        private readonly IFactory<HeartbeatDataSourceReport> _factory;

        public HeartbeatRequestFactoryDataSourceInterceptor(
            IFactory<HeartbeatDataSourceReport> factory)
        {
            Argument.NotNull(factory, nameof(factory));

            _factory = factory;
        }

        public void Created(CreateIntegrationUserHeartbeatV1Request result)
        {
            Argument.NotNull(result, nameof(result));

            var report = _factory.Create();

            result.DataSourceEnabled = report.DataSourceEnabled;
            result.DataSources = report.DataSources;
        }
    }
}
