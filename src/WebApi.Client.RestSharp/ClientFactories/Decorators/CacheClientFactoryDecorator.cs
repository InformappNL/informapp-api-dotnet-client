using Informapp.InformSystem.WebApi.Client.Caches;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using Informapp.InformSystem.WebApi.Client.RestSharp.Requires;
using RestSharp;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IClientFactory"/> to cache client
    /// </summary>
    public class CacheClientFactoryDecorator : Decorator<IClientFactory>,
        IClientFactory
    {
        private readonly IClientFactory _clientFactory;

        private readonly IClientCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheClientFactoryDecorator"/> class.
        /// </summary>
        /// <param name="clientFactory">The instance to decorate</param>
        /// <param name="cache">The instance to cache client instances</param>
        public CacheClientFactoryDecorator(
            IClientFactory clientFactory,
            IClientCache cache) : base(clientFactory)   
        {
            Argument.NotNull(clientFactory, nameof(clientFactory));
            Argument.NotNull(cache, nameof(cache));

            _clientFactory = clientFactory;

            _cache = cache;
        }

        /// <summary>
        /// Create instance of <see cref="IRestClient"/> and cache it
        /// </summary>
        /// <param name="request">The request to create a client for</param>
        /// <returns>The created instance of <see cref="IRestClient"/></returns>
        public IRestClient Create(ApiRequest request)
        {
            Argument.NotNull(request, nameof(request));

            var client = _cache.GetOrAdd(request.Context.EndPoint, () => _clientFactory.Create(request));

            Require.NotNull(client, nameof(client));

            return client;
        }
    }
}
