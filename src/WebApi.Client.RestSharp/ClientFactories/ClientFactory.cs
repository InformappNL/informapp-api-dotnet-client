using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.Requires;
using RestSharp;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp.ClientFactories
{
    /// <summary>
    ///  Factory class to create instances of <see cref="IRestClient"/>
    /// </summary>
    public class ClientFactory : IClientFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientFactory"/> class.
        /// </summary>
        public ClientFactory()
        {

        }

        /// <summary>
        /// Create instance of <see cref="IRestClient"/>
        /// </summary>
        /// <param name="request">The request to create a client for</param>
        /// <returns>The created instance of <see cref="IRestClient"/></returns>
        public IRestClient Create(ApiRequest request)
        {
            Argument.NotNull(request, nameof(request));

            var endPoint = request?.Context?.EndPoint;

            Require.NotNull(endPoint, nameof(endPoint));

            var client = new RestClient(endPoint);

            return client;
        }
    }
}
