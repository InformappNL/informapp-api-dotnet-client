﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.AttributeProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Files;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set the download file on the response model
    /// </summary>
    public class DownloadFileApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private static readonly DownloadFileRequestAttribute _attribute = AttributeProvider.Create<TRequest, DownloadFileRequestAttribute>(inherit: true)
            .ThrowIfMultiple()
            .Attribute;

        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IReadOnlyList<IDownloadFileMapper<TRequest, TResponse>> _mappers;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadFileApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="mappers">The download file mappers</param>
        public DownloadFileApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IReadOnlyList<IDownloadFileMapper<TRequest, TResponse>> mappers) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNullOrEmpty(mappers, nameof(mappers));

            _apiClient = apiClient;

            _mappers = mappers;
        }

        /// <summary>
        /// Execute request and set the download file on the response model
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<ApiResponse<TResponse>> Execute(ApiRequest<TRequest> request, CancellationToken cancellationToken)
        {
            Argument.NotNull(request, nameof(request));

            bool isFileDownload = _attribute != null;

            if (isFileDownload == true)
            {
                request.IsFileDownload = isFileDownload;
            }

            var response = await _apiClient
                .Execute(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));

            if (isFileDownload == true)
            {
                if (response.IsSuccessful == true)
                {
                    bool mapped = false;

                    foreach (var mapper in _mappers)
                    {
                        mapped = mapper.Map(response);

                        if (mapped == true)
                        {
                            break;
                        }
                    }

                    if (mapped == false)
                    {
                        throw new InvalidOperationException("Failed to map download file response");
                    }
                }
            }

            return response;
        }
    }
}
