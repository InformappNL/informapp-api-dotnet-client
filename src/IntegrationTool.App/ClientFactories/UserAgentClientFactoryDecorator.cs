using ConnectedDevelopment.InformSystem.IntegrationTool.Core;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.ClientFactories;
using RestSharp;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.ClientFactories
{
    /// <summary>
    /// User agent client factory decorator
    /// </summary>
    public class UserAgentClientFactoryDecorator : Decorator<IClientFactory>,
        IClientFactory
    {
        private readonly IClientFactory _clientFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CancellationEventHandler"/> class.
        /// </summary>
        /// <param name="clientFactory">The decorated clientfactory</param>
        public UserAgentClientFactoryDecorator(
            IClientFactory clientFactory) : base(clientFactory)
        {
            Argument.NotNull(clientFactory, nameof(clientFactory));

            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Create rest client and set the user agent
        /// </summary>
        /// <param name="request">The request instance</param>
        /// <returns>The rest client instance</returns>
        public IRestClient Create(ApiRequest request)
        {
            Argument.NotNull(request, nameof(request));

            var client = _clientFactory.Create(request);

            client.UserAgent = VersionConstants.Version;

            return client;
        }
    }
}
