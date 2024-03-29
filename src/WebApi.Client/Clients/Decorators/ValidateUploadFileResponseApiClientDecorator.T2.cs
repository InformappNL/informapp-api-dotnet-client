﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to validate the uploaded file
    /// </summary>
    public class ValidateUploadFileResponseApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private readonly IApiClient<TRequest, TResponse> _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateUploadFileResponseApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        public ValidateUploadFileResponseApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));

            _apiClient = apiClient;
        }

        /// <summary>
        /// Execute request and validate the uploaded file
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

            if (response.IsSuccessful == true &&
                request.IsFileUpload == true)
            {
                Require.NotNull(request.UploadFile, nameof(request.UploadFile));
                Require.NotNull(response.UploadFile, nameof(response.UploadFile));

                if (request.UploadFile != null &&
                    response.UploadFile != null)
                {
                    if (request.UploadFile.Size != response.UploadFile.Size)
                    {
                        string message = string.Format(
                            CultureInfo.CurrentCulture,
                            "File upload failed, file sizes differ. Local size: {0}, remote size: {1}",
                            request.UploadFile.Size,
                            response.UploadFile.Size);

                        throw new InvalidOperationException(message);
                    }

                    if (response.UploadFile.Algorithm.HasValue == true)
                    {
                        if (string.Equals(
                            request.UploadFile.HashBase64,
                            response.UploadFile.HashBase64,
                            StringComparison.Ordinal) == false)
                        {
                            string message = string.Format(
                                CultureInfo.CurrentCulture,
                                "File upload failed, hashes differ. Local hash: {0}, remote hash: {1}",
                                request.UploadFile.HashBase64,
                                response.UploadFile.HashBase64);

                            throw new InvalidOperationException(message);
                        }
                    }
                }
            }

            return response;
        }
    }
}
