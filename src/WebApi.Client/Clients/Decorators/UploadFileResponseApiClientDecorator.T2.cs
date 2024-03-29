﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.AttributeProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Converters;
using ConnectedDevelopment.InformSystem.WebApi.Client.Cryptography;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Files;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set upload file on the response
    /// </summary>
    public class UploadFileResponseApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private static readonly UploadFileResponseAttribute _attribute = AttributeProvider.Create<TResponse, UploadFileResponseAttribute>(inherit: true)
            .ThrowIfMultiple()
            .Attribute;

        private readonly IApiClient<TRequest, TResponse> _apiClient;

        private readonly IReadOnlyList<IUploadFileResponseMapper<TRequest, TResponse>> _mappers;

        private readonly IConverter<HashAlgorithmKind?, HashAlgorithm> _converter;

        private readonly IHasher _hasher;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileResponseApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        /// <param name="mappers">The upload file mappers</param>
        /// <param name="converter">The converter</param>
        /// <param name="hasher">The hasher</param>
        public UploadFileResponseApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient,
            IReadOnlyList<IUploadFileResponseMapper<TRequest, TResponse>> mappers,
            IConverter<HashAlgorithmKind?, HashAlgorithm> converter,
            IHasher hasher) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));
            Argument.NotNull(mappers, nameof(mappers));
            Argument.NotNull(converter, nameof(converter));
            Argument.NotNull(hasher, nameof(hasher));

            _apiClient = apiClient;

            _mappers = mappers;

            _converter = converter;

            _hasher = hasher;
        }

        /// <summary>
        /// Execute request and set upload file on the response
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

            Require.NotNull(response, nameof(response));

            bool isFileUploadResponse = _attribute != null;

            if (isFileUploadResponse == true &&
                response.IsSuccessful == true)
            {
                var fileResponse = new ApiUploadFileResponse();

                response.UploadFile = fileResponse;

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
                    throw new InvalidOperationException("Failed to map upload file response");
                }

                var file = request.UploadFile.File;

                if (fileResponse.Algorithm.HasValue == true)
                {
                    if (file.CanSeek == false)
                    {
                        throw new InvalidOperationException("The stream must support seek operations");
                    }

                    if (file.CanSeek == true)
                    {
                        file.Position = 0L;

                        using (
                            var algorithm = _converter
                                .Convert(fileResponse.Algorithm)
                                .ThrowIfNoValue()
                                .Value)
                        {
                            var hash = await _hasher
                                .ComputeHashAsync(algorithm, file, cancellationToken)
                                .ConfigureAwait(Await.Default);

                            request.UploadFile.Algorithm = response.UploadFile.Algorithm;
                            request.UploadFile.Hash = hash;
                            request.UploadFile.HashBase64 = Convert.ToBase64String(hash);

                            response.UploadFile.HashBase64 = Convert.ToBase64String(fileResponse.Hash);
                        }
                    }
                }
            }

            return response;
        }
    }
}
