using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;

namespace Informapp.InformSystem.IntegrationTool.Core.Factories
{
    /// <summary>
    /// Factory for creating a heartbeat request
    /// </summary>
    public class HeartbeatRequestFactory : IFactory<CreateIntegrationUserHeartbeatV1Request>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatRequestFactory"/> class.
        /// </summary>
        public HeartbeatRequestFactory()
        {

        }

        /// <summary>
        /// Creates the heartbeat request
        /// </summary>
        /// <returns>The heartbeat request</returns>
        public CreateIntegrationUserHeartbeatV1Request Create()
        {
            string version = VersionConstants.Version;

            var request = new CreateIntegrationUserHeartbeatV1Request
            {
                Version = version,
            };

            return request;
        }
    }
}
