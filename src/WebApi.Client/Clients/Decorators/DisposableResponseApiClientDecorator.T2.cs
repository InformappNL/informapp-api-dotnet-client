using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Disposables;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Requires;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to register the response object for disposal
    /// </summary>
    public class DisposableResponseApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IDisposableResources _disposableResources;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableResponseApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="disposableResources">The disposable resources</param>
        public DisposableResponseApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IDisposableResources disposableResources) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(disposableResources, nameof(disposableResources));

            _apiClient = apiClient;

            _disposableResources = disposableResources;
        }

        /// <summary>
        /// Execute request and register the response object for disposal
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
                _disposableResources.TryRegisterForDisposal(response.Model);
            }

            if (response.DownloadFile != null &&
                response.DownloadFile.File != null)
            {
                _disposableResources.RegisterForDisposal(response.DownloadFile.File);
            }

            return response;
        }
    }
}
