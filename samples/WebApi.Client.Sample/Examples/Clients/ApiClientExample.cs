using ConnectedDevelopment.InformSystem.WebApi.Client.Configuration;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.ListValues;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.Clients
{
    /// <summary>
    /// Example using the api client facade
    /// </summary>
    public class ApiClientExample : IExample
    {
        private readonly IOptions<ApiConfiguration> _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientExample"/> class.
        /// </summary>
        public ApiClientExample(
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
