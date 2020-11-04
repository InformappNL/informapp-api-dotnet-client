using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using RestSharp;
using RestSharp.Serialization;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.ClientFactories.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IClientFactory"/> to set serializer
    /// </summary>
    public class SerializerClientFactoryDecorator : Decorator<IClientFactory>,
        IClientFactory
    {
        private readonly IClientFactory _clientFactory;

        private readonly IRestSerializer _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializerClientFactoryDecorator"/> class.
        /// </summary>
        /// <param name="clientFactory">The instance to decorate</param>
        /// <param name="serializer">The serializer</param>
        public SerializerClientFactoryDecorator(
            IClientFactory clientFactory,
            IRestSerializer serializer) : base(clientFactory)
        {
            Argument.NotNull(clientFactory, nameof(clientFactory));
            Argument.NotNull(serializer, nameof(serializer));

            _clientFactory = clientFactory;

            _serializer = serializer;
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

            client.UseSerializer(() => _serializer);

            return client;
        }
    }
}
