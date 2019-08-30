using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.RestSharp.Arguments;
using Informapp.InformSystem.WebApi.Models.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.RestSharp.RequestFactories.Decorators
{
    /// <summary>
    /// Decorator class for <see cref="IRequestFactory"/> to set accept header
    /// </summary>
    public class AcceptContentTypeRequestFactoryDecorator : Decorator<IRequestFactory>,
        IRequestFactory
    {
        private readonly IRequestFactory _requestFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AcceptContentTypeRequestFactoryDecorator"/> class.
        /// </summary>
        /// <param name="requestFactory">The instance to decorate</param>
        public AcceptContentTypeRequestFactoryDecorator(
            IRequestFactory requestFactory) : base(requestFactory)
        {
            Argument.NotNull(requestFactory, nameof(requestFactory));

            _requestFactory = requestFactory;
        }

        /// <summary>
        /// Create instance of <see cref="IRestRequest"/> and set accept header
        /// </summary>
        /// <param name="request">The request instance</param>
        /// <returns>The constructed <see cref="IRestRequest"/> instance</returns>
        public IRestRequest Create(ApiRequest request)
        {
            Argument.NotNull(request, nameof(request));

            var apiRequest = _requestFactory.Create(request);

            if (request.Context.Accept.HasValue == true)
            {
                string accept;

                switch (request.Context.Accept.Value)
                {
                    case Accept.Json:
                        accept = ContentTypeConstants.Application.Json;
                        break;
                    case Accept.OctetStream:
                        accept = ContentTypeConstants.Application.OctetStream;
                        break;
                    default:
                        throw new InvalidOperationException("Unsupported value");
                }

                apiRequest.AddOrUpdateParameter(HttpRequestHeaderConstants.Accept, accept);
            }

            return apiRequest;
        }
    }
}
