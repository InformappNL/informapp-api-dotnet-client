using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Informapp.InformSystem.IntegrationTool.Core.Factories;
using Informapp.InformSystem.IntegrationTool.Core.Requires;
using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Applications
{
    /// <summary>
    /// Heartbeat application decorator
    /// </summary>
    public class HeartbeatApplicationDecorator : Decorator<IApplication>,
        IApplication
    {
        private readonly IApplication _application;

        private readonly IOptions<IntegrationConfiguration> _integrationConfiguration;

        private readonly IFactory<CreateIntegrationUserHeartbeatV1Request> _requestFactory;

        private readonly IApiClient<CreateIntegrationUserHeartbeatV1Request, CreateIntegrationUserHeartbeatV1Response> _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatApplicationDecorator"/> class.
        /// </summary>
        public HeartbeatApplicationDecorator(
            IApplication application,
            IOptions<IntegrationConfiguration> integrationConfiguration,
            IFactory<CreateIntegrationUserHeartbeatV1Request> requestFactory,
            IApiClient<CreateIntegrationUserHeartbeatV1Request, CreateIntegrationUserHeartbeatV1Response> apiClient) : base(application)
        {
            Argument.NotNull(application, nameof(application));
            Argument.NotNull(integrationConfiguration, nameof(integrationConfiguration));
            Argument.NotNull(requestFactory, nameof(requestFactory));
            Argument.NotNull(apiClient, nameof(apiClient));

            _application = application;

            _integrationConfiguration = integrationConfiguration;

            _requestFactory = requestFactory;

            _apiClient = apiClient;
        }

        /// <summary>
        /// Run the application
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task to run</returns>
        public Task Run(CancellationToken cancellationToken)
        {
            var configuration = _integrationConfiguration.Value;

            Require.NotNull(configuration, nameof(configuration));

            if (configuration.HeartbeatEnabled == true)
            {
                return RunWithHeartbeat(cancellationToken);
            }
            else
            {
                return _application.Run(cancellationToken);
            }
        }

        private async Task RunWithHeartbeat(CancellationToken cancellationToken)
        {
            var request = _requestFactory.Create();

            _ = await _apiClient
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            await _application
                .Run(cancellationToken)
                .ConfigureAwait(Await.Default);
        }
    }
}
