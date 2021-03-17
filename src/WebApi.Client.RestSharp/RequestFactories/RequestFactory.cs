using Informapp.InformSystem.WebApi.Client.Converters;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using Informapp.InformSystem.WebApi.Models.Http;
using RestSharp;
using System;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.RequestFactories
{
    /// <summary>
    /// Factory class to create <see cref="IRestRequest"/> instances
    /// </summary>
    public class RequestFactory : IRequestFactory
    {
        private readonly IConverter<HttpMethod?, Method?> _converter;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestFactory"/> class.
        /// </summary>
        /// <param name="converter"></param>
        public RequestFactory(
            IConverter<HttpMethod?, Method?> converter)
        {
            Argument.NotNull(converter, nameof(converter));

            _converter = converter;
        }

        /// <summary>
        /// Create instance of <see cref="IRestRequest"/>
        /// </summary>
        /// <param name="request">The request instance</param>
        /// <returns>The constructed <see cref="IRestRequest"/> instance</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is null</exception>
        public IRestRequest Create(ApiRequest request)
        {
            Argument.NotNull(request, nameof(request));

            var method = _converter.Convert(request.Context.Method.Value)
                .ThrowIfNoValue()
                .Value;

            var resource = request.Context.Path;

            if (string.IsNullOrEmpty(request.Context.Query) == false)
            {
                resource = new Uri(resource.ToString() + '?' + request.Context.Query, UriKind.Relative);
            }

            var apiRequest = new RestRequest(resource, method.Value);

            // Set default content type to JSON, override using a decorator and AddOrUpdateParameter method
            _ = apiRequest.AddHeader(HttpRequestHeaderConstants.Accept, ContentTypeConstants.Application.Json);

            return apiRequest;
        }
    }
}
