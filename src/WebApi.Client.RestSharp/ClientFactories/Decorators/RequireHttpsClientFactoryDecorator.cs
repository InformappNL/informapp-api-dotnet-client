using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Exceptions;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.Requires;
using RestSharp;
using System;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.ClientFactories.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IClientFactory"/> to require the use of HTTPS
    /// </summary>
    public class RequireHttpsClientFactoryDecorator : Decorator<IClientFactory>,
        IClientFactory
    {
        private readonly IClientFactory _clientFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequireHttpsClientFactoryDecorator"/> class.
        /// </summary>
        /// <param name="clientFactory">The instance to decorate</param>
        public RequireHttpsClientFactoryDecorator(
            IClientFactory clientFactory) : base(clientFactory)
        {
            Argument.NotNull(clientFactory, nameof(clientFactory));

            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Create instance of <see cref="IRestClient"/> after ensuring HTTPS is used
        /// </summary>
        /// <param name="request">The request to create a client for</param>
        /// <returns>The created instance of <see cref="IRestClient"/></returns>
        public IRestClient Create(ApiRequest request)
        {
            Argument.NotNull(request, nameof(request));

            string scheme = request.Context?.EndPoint?.Scheme;

            Require.NotNull(scheme, nameof(scheme));

            bool isSecure = string.Equals(scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase);

            if (isSecure == false)
            {
                throw new ApiClientException("HTTPS is required.");
            }

            return _clientFactory.Create(request);
        }
    }
}
