using Informapp.InformSystem.WebApi.Client.Configuration;
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
    /// Example using the api client facade
    /// </summary>
    internal class ApiClientExample : IExample
    {
        private readonly IOptions<ApiConfiguration> _options;

        public ApiClientExample(
            IOptions<ApiConfiguration> options)
        {
            Argument.NotNull(options, nameof(options));

            _options = options;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var client = new ApiClient<ListValuesV1Request, ListValuesV1Response>(_options);

            var request = ApiRequest.Create(new ListValuesV1Request());

            var response = await client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
