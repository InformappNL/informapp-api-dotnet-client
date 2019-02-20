using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using Informapp.InformSystem.WebApi.Models.OAuth2;
using RestSharp;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.RequestFactories.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IRequestFactory"/> to set bearer token
    /// </summary>
    public class BearerTokenRequestFactoryDecorator : Decorator<IRequestFactory>,
        IRequestFactory
    {
        private readonly IRequestFactory _requestFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BearerTokenRequestFactoryDecorator"/> class.
        /// </summary>
        /// <param name="requestFactory">The instance to decorate</param>
        public BearerTokenRequestFactoryDecorator(
            IRequestFactory requestFactory) : base(requestFactory)
        {
            Argument.NotNull(requestFactory, nameof(requestFactory));

            _requestFactory = requestFactory;
        }

        /// <summary>
        /// Create instance of <see cref="IRestRequest"/> and set bearer token
        /// </summary>
        /// <param name="request">The request instance</param>
        /// <returns>The constructed <see cref="IRestRequest"/> instance</returns>
        public IRestRequest Create(ApiRequest request)
        {
            Argument.NotNull(request, nameof(request));

            var apiRequest = _requestFactory.Create(request);

            if (request.BearerToken != null && request.BearerToken.HasToken == true)
            {
                string name = AOuth2Constants.AuthorizationHeaderName;

                string value = AOuth2Constants.AuthorizationHeaderValuePrefix + ' ' + request.BearerToken.GetToken();

                apiRequest.AddParameter(name, value, ParameterType.HttpHeader);
            }

            return apiRequest;
        }
    }
}
