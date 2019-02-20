using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using Informapp.InformSystem.WebApi.Client.RestSharp.Deserializers;
using Informapp.InformSystem.WebApi.Models.Http;
using RestSharp;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IClientFactory"/> to set JSON deserializer
    /// </summary>
    public class JsonDeserializerClientFactoryDecorator : Decorator<IClientFactory>,
        IClientFactory
    {
        private readonly IClientFactory _clientFactory;

        private readonly IJsonDeserializer _jsonDeserializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDeserializerClientFactoryDecorator"/> class.
        /// </summary>
        /// <param name="clientFactory">The instance to decorate</param>
        /// <param name="jsonDeserializer"></param>
        public JsonDeserializerClientFactoryDecorator(
            IClientFactory clientFactory,
            IJsonDeserializer jsonDeserializer) : base(clientFactory)
        {
            Argument.NotNull(clientFactory, nameof(clientFactory));
            Argument.NotNull(jsonDeserializer, nameof(jsonDeserializer));

            _clientFactory = clientFactory;

            _jsonDeserializer = jsonDeserializer;
        }

        /// <summary>
        /// Create instance of <see cref="IRestClient"/> and set JSON deserializer
        /// </summary>
        /// <param name="request">The request to create a client for</param>
        /// <returns>The created instance of <see cref="IRestClient"/></returns>
        public IRestClient Create(ApiRequest request)
        {
            Argument.NotNull(request, nameof(request));

            var client = _clientFactory.Create(request);

            client.AddHandler(ContentTypeConstants.Application.Json, _jsonDeserializer);

            return client;
        }
    }
}
