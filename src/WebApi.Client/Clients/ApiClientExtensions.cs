using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Clients
{
    /// <summary>
    /// Extension methods for <see cref="IApiClient{TRequest, TResponse}"/>
    /// </summary>
    public static class ApiClientExtensions
    {
        /// <summary>
        /// Execute request without having to explicitly create an instance of <see cref="ApiRequest{T}"/>
        /// </summary>
        /// <typeparam name="TRequest">Request type</typeparam>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="client">The api client</param>
        /// <param name="model">The request model</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public static Task<ApiResponse<TResponse>> Execute<TRequest, TResponse>(
            this IApiClient<TRequest, TResponse> client, 
            TRequest model,
            CancellationToken cancellationToken = default(CancellationToken))

            where TRequest : class, IRequest<TResponse>
            where TResponse : class
        {
            Argument.NotNull(client, nameof(client));
            Argument.NotNull(model, nameof(model));

            var request = ApiRequest.Create(model);

            return client.Execute(request, cancellationToken);
        }
    }
}
