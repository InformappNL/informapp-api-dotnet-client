using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Requires;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Validators;
using Informapp.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to validate response model
    /// </summary>
    public class ValidateResponseModelApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IValidator<TResponse> _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateResponseModelApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="validator"></param>
        public ValidateResponseModelApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IValidator<TResponse> validator) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(validator, nameof(validator));

            _apiClient = apiClient;

            _validator = validator;
        }

        /// <summary>
        /// Execute request and validate response model
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            var response = await _apiClient.Execute(request, cancellationToken);

            Require.NotNull(response, nameof(response));

            if (response.Model != null)
            {
                _validator.ValidateObject(response.Model);
            }

            return response;
        }
    }
}
