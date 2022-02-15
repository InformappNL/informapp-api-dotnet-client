using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    public class HeartbeatRequestFactoryConfigurationInterceptor : IFactoryInterceptor<CreateIntegrationUserHeartbeatV1Request>
    {
        private readonly IFactory<HeartbeatConfigurationReport> _factory;

        public HeartbeatRequestFactoryConfigurationInterceptor(
            IFactory<HeartbeatConfigurationReport> factory)
        {
            Argument.NotNull(factory, nameof(factory));

            _factory = factory;
        }

        public void Created(CreateIntegrationUserHeartbeatV1Request result)
        {
            Argument.NotNull(result, nameof(result));

            var report = _factory.Create();

            result.Configuration = report.Configuration;
        }
    }
}
