using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    public class HeartbeatRequestFactoryDriveInterceptor : IFactoryInterceptor<CreateIntegrationUserHeartbeatV1Request>
    {
        private readonly IFactory<HeartbeatDriveInfoReport> _factory;

        public HeartbeatRequestFactoryDriveInterceptor(
            IFactory<HeartbeatDriveInfoReport> factory)
        {
            Argument.NotNull(factory, nameof(factory));

            _factory = factory;
        }

        public void Created(CreateIntegrationUserHeartbeatV1Request result)
        {
            Argument.NotNull(result, nameof(result));

            var report = _factory.Create();

            result.Drives = report.Drives;
        }
    }
}
