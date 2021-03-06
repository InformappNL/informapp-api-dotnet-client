﻿using Informapp.InformSystem.WebApi.Client.Configuration;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Clients;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.ListValues;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Clients
{
    /// <summary>
    /// Example using the factory
    /// </summary>
    public class ApiClientFactoryExample : IExample
    {
        private readonly IOptions<ApiConfiguration> _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientFactoryExample"/> class.
        /// </summary>
        public ApiClientFactoryExample(
            IOptions<ApiConfiguration> options)
        {
            Argument.NotNull(options, nameof(options));

            _options = options;
        }

        /// <summary>
        /// Execute example
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            var factory = new ApiClientFactory(_options);

            var client = factory.Create<ListValuesV1Request, ListValuesV1Response>();

            var request = ApiRequest.Create(new ListValuesV1Request());

            var response = await client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
