using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using Informapp.InformSystem.WebApi.Models.Http;
using RestSharp;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.RequestFactories.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IRequestFactory"/> to override HTTP method
    /// </summary>
    public class MethodOverrideRequestFactoryDecorator : Decorator<IRequestFactory>,
        IRequestFactory
    {
        private readonly IRequestFactory _requestFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodOverrideRequestFactoryDecorator"/> class.
        /// </summary>
        /// <param name="requestFactory">The instance to decorate</param>
        public MethodOverrideRequestFactoryDecorator(
            IRequestFactory requestFactory) : base(requestFactory)
        {
            Argument.NotNull(requestFactory, nameof(requestFactory));

            _requestFactory = requestFactory;
        }

        /// <summary>
        /// Create instance of <see cref="IRestRequest"/> and override HTTP method
        /// </summary>
        /// <param name="request">The request instance</param>
        /// <returns>The constructed <see cref="IRestRequest"/> instance</returns>
        public IRestRequest Create(ApiRequest request)
        {
            Argument.NotNull(request, nameof(request));

            bool overridden = false;

            var method = request.Context.Method;

            if (request.Context.MethodOverride == true &&
                method.HasValue == true &&
                HttpMethodOverride.IsOverridable(method.Value) == true)
            {
                overridden = true;

                request.Context.Method = HttpMethod.Post;
            }

            var apiRequest = _requestFactory.Create(request);

            if (overridden == true)
            {
                request.Context.Method = method;

                apiRequest.AddHeader(HttpMethodOverride.HeaderName, method.Value.ToString());
            }

            return apiRequest;
        }
    }
}
