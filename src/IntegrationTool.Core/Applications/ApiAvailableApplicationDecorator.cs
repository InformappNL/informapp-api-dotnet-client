using Informapp.InformSystem.IntegrationTool.Core.Resources;
using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Pings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Applications
{
    /// <summary>
    /// Api available application decorator
    /// </summary>
    public class ApiAvailableApplicationDecorator : Decorator<IApplication>,
        IApplication
    {
        private readonly IApplication _application;

        private readonly IApiClient<PingV1Request, PingV1Response> _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiAvailableApplicationDecorator"/> class.
        /// </summary>
        public ApiAvailableApplicationDecorator(
            IApplication application,
            IApiClient<PingV1Request, PingV1Response> apiClient) : base(application)
        {
            Argument.NotNull(application, nameof(application));
            Argument.NotNull(apiClient, nameof(apiClient));

            _application = application;

            _apiClient = apiClient;
        }

        /// <summary>
        /// Run the application
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task to run</returns>
        public async Task Run(CancellationToken cancellationToken)
        {
            var request = new PingV1Request();

            var response = await _apiClient
                .Execute(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            if (response.IsSuccessful == true)
            {
                await _application
                    .Run(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
            else
            {
                throw new InvalidOperationException(ExceptionResource.ApiUnavailable);
            }
        }
    }
}
