using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.ListValues;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.Clients
{
    /// <summary>
    /// Example using dependency injection
    /// </summary>
    public class DependencyInjectionExample : IExample
    {
        private readonly IApiClient<ListValuesV1Request, ListValuesV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyInjectionExample"/> class.
        /// </summary>
        public DependencyInjectionExample(
            IApiClient<ListValuesV1Request, ListValuesV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        /// <summary>
        /// Execute example
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            var request = new ListValuesV1Request();

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
