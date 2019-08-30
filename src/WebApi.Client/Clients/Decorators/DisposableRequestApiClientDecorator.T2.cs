using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Disposables;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Models.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to register the request object for disposal
    /// </summary>
    public class DisposableRequestApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IDisposableResources _disposableResources;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableRequestApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="disposableResources">The disposable resources</param>
        public DisposableRequestApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IDisposableResources disposableResources) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(disposableResources, nameof(disposableResources));

            _apiClient = apiClient;

            _disposableResources = disposableResources;
        }

        /// <summary>
        /// Register the request object for disposal and execute request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            if (request.Model != null)
            {
                _disposableResources.TryRegisterForDisposal(request.Model);
            }

            if (request.UploadFile != null &&
                request.UploadFile.File != null)
            {
                _disposableResources.RegisterForDisposal(request.UploadFile.File);
            }

            return _apiClient.Execute(request, cancellationToken);
        }
    }
}
