using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Requests;
using Informapp.InformSystem.WebApi.Models.Responses;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set request total count on response
    /// </summary>
    public class TotalCountApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TotalCountApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        public TotalCountApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));

            _apiClient = apiClient;
        }

        /// <summary>
        /// Execute request and set total count on response
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            var response = await _apiClient.Execute(request, cancellationToken);

            if (response.Headers != null)
            {
                var header = response.Headers
                    .Where(x => string.Equals(x.Name, ResponseHeaderConstants.TotalCountHeaderName, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();

                if (header != null)
                {
                    if (int.TryParse(header.Value, NumberStyles.None, CultureInfo.InvariantCulture, out int totalCount))
                    {
                        response.TotalCount = totalCount;
                    }
                }
            }

            return response;
        }
    }
}
