using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    public class HeartbeatRequestFactoryIntegrationExportInterceptor : IFactoryInterceptor<CreateIntegrationUserHeartbeatV1Request>
    {
        private readonly IFactory<HeartbeatIntegrationExportReport> _factory;

        public HeartbeatRequestFactoryIntegrationExportInterceptor(
            IFactory<HeartbeatIntegrationExportReport> factory)
        {
            Argument.NotNull(factory, nameof(factory));

            _factory = factory;
        }

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
