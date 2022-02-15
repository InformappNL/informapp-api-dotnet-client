using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    public class HeartbeatRequestFactoryIntegrationImportInterceptor : IFactoryInterceptor<CreateIntegrationUserHeartbeatV1Request>
    {
        private readonly IFactory<HeartbeatIntegrationImportReport> _factory;

        public HeartbeatRequestFactoryIntegrationImportInterceptor(
            IFactory<HeartbeatIntegrationImportReport> factory)
        {
            Argument.NotNull(factory, nameof(factory));

            _factory = factory;
        }

        public void Created(CreateIntegrationUserHeartbeatV1Request result)
        {
            Argument.NotNull(result, nameof(result));

            var report = _factory.Create();

            result.IntegrationImportEnabled = report.Enabled;
            result.IntegrationImports = report.IntegrationImports;
        }
    }
}
