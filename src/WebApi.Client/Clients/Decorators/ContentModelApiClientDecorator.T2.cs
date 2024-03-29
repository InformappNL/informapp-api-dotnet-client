﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.AttributeProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Clients.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IApiClient{TRequest, TResponse}"/> to set content model
    /// </summary>
    public class ContentModelApiClientDecorator<TRequest, TResponse> : Decorator<IApiClient<TRequest, TResponse>>,
        IApiClient<TRequest, TResponse>

        where TRequest : class, IRequest<TResponse>
        where TResponse : class, new()
    {
        private static readonly IDictionary<HttpStatusCode, Type> _models = AttributeProvider.Create<TRequest, ResponseAttribute>(inherit: true)
            .GetAttributes()
            .ToDictionary(x => x.StatusCode, x => x.Model);

        private readonly IApiClient<TRequest, TResponse> _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentModelApiClientDecorator{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="apiClient">The instance to decorate</param>
        public ContentModelApiClientDecorator(
            IApiClient<TRequest, TResponse> apiClient) : base(apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));

            _apiClient = apiClient;
        }

        /// <summary>
        /// Execute request and set content model
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

            SetContentModel(response);

            return response;
        }

        private static void SetContentModel(ApiResponse<TResponse> response)
        {
            if (response.ContentModel == null &&
                response.StatusCode.HasValue == true &&
                string.IsNullOrEmpty(response.Content) == false &&
                response.Headers != null &&
                string.IsNullOrEmpty(response.Headers.ContentType) == false)
            {
                var contentTypes = response.Headers.ContentType
                    .Split(ContentTypeConstants.ResponseHeaderSeparator);

                bool isJsonContentType = contentTypes
                    .Contains(ContentTypeConstants.Application.Json, StringComparer.OrdinalIgnoreCase);

                if (_models.TryGetValue(response.StatusCode.Value, out var modelType) == true)
                {
                    if (modelType == typeof(TResponse))
                    {
                        response.ContentModel = response.Model;
                    }
                    else
                    {
                        if (isJsonContentType == true)
                        {
                            response.ContentModel = JsonDeserializeObject(response.Content, modelType);
                        }
                        else
                        {
                            response.ContentModel = response.Content;
                        }
                    }
                }
                else
                {
                    if (response.IsSuccessful == true)
                    {
                        response.ContentModel = response.Model;
                    }
                    else
                    {
                        if (isJsonContentType == true)
                        {
                            response.ContentModel = JsonDeserializeObject(response.Content);
                        }
                        else
                        {
                            response.ContentModel = response.Content;
                        }
                    }
                }
            }
        }

        private static readonly JsonSerializerSettings _jsonSettings =
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };

        private static object JsonDeserializeObject(string value, Type type = null)
        {
            try
            {
                if (type == null)
                {
                    return JsonConvert.DeserializeObject(value, _jsonSettings);
                }
                else
                {
                    return JsonConvert.DeserializeObject(value, type, _jsonSettings);
                }
            }
            catch (Exception)
            {
                return value;
            }
        }
    }
}
