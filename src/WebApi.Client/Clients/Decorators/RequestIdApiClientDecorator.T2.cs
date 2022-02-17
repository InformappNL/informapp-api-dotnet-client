using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Converters;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set request id on response
    /// </summary>
    public class RequestIdApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IConverter<string, Guid?> _converter;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestIdApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="converter"></param>
        public RequestIdApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IConverter<string, Guid?> converter) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(converter, nameof(converter));

            _apiClient = apiClient;

            _converter = converter;
        }

        /// <summary>
        /// Execute request and set request id on response
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            var response = await _apiClient
                .Execute(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            if (response.Headers != null)
            {
                var header = response.Headers.GetHeader(ResponseHeaderConstants.RequestIdHeaderName);

                if (header != null && header.HasValue == true)
                {
                    var requestId = _converter.Convert(header.Value)
                        .Value;

                    response.Headers.RequestId = requestId;
                }
            }

            return response;
        }
    }
}
