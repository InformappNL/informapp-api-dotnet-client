using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Validators;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to validate request context
    /// </summary>
    public class ValidateRequestContextApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IValidator<RequestContext> _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateRequestContextApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="validator"></param>
        public ValidateRequestContextApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IValidator<RequestContext> validator) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(validator, nameof(validator));

            _apiClient = apiClient;

            _validator = validator;
        }

        /// <summary>
        /// Validate request context and execute request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));
            Argument.NotNull(request.Model, nameof(request.Context));

            _validator.ValidateObject(request.Context);

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
