using Informapp.InformSystem.WebApi.Client.Configuration;
using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Requests;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Clients
{
    /// <summary>
    /// Api client facade class
    /// </summary>
    /// <typeparam name="TRequest">The request type</typeparam>
    /// <typeparam name="TResponse">The response type</typeparam>
    public class ApiClient<TRequest, TResponse> : IApiClient<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient{TRequest, TResponse}"/> class and act on a client created by the static factory
        /// </summary>
        public ApiClient(IOptions<ApiConfiguration> options)
        {
            Argument.NotNull(options, nameof(options));

            var factory = new ApiClientFactory(options);

            var client = factory.Create<TRequest, TResponse>();

            Require.NotNull(client, nameof(client));

            _client = client;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient{TRequest, TResponse}"/> class and act on the provided client
        /// </summary>
        /// <param name="client">The client to use</param>
        public ApiClient(
            IApiClient<TRequest, TResponse> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        /// <summary>
        /// Execute request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<ApiResponse<TResponse>> Execute(
            ApiRequest<TRequest> request,
            CancellationToken cancellationToken)
        {
            return _client.Execute(request, cancellationToken);
        }
    }
}
