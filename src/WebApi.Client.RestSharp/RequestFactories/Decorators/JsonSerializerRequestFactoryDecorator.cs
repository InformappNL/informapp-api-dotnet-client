using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using Informapp.InformSystem.WebApi.Client.RestSharp.Serializers;
using RestSharp;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.RequestFactories.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IRequestFactory"/> to set JSON serializer
    /// </summary>
    public class JsonSerializerRequestFactoryDecorator : Decorator<IRequestFactory>,
        IRequestFactory
    {
        private readonly IRequestFactory _requestFactory;

        private readonly IJsonSerializer _jsonSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSerializerRequestFactoryDecorator"/> class.
        /// </summary>
        /// <param name="requestFactory">The instance to decorate</param>
        /// <param name="jsonSerializer"></param>
        public JsonSerializerRequestFactoryDecorator(
            IRequestFactory requestFactory,
            IJsonSerializer jsonSerializer) : base(requestFactory)
        {
            Argument.NotNull(requestFactory, nameof(requestFactory));
            Argument.NotNull(jsonSerializer, nameof(jsonSerializer));

            _requestFactory = requestFactory;

            _jsonSerializer = jsonSerializer;
        }

        /// <summary>
        /// Create instance of <see cref="IRestRequest"/> and set JSON serializer
        /// </summary>
        /// <param name="request">The request instance</param>
        /// <returns>The constructed <see cref="IRestRequest"/> instance</returns>
        public IRestRequest Create(ApiRequest request)
        {
            Argument.NotNull(request, nameof(request));

            var apiRequest = _requestFactory.Create(request);

            apiRequest.JsonSerializer = _jsonSerializer;

            return apiRequest;
        }
    }
}
