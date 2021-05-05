using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Pings;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Pings
{
    /// <summary>
    /// Example for ping
    /// </summary>
    public class PingV1Example : IExample
    {
        private readonly IApiClient<PingV1Request, PingV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="PingV1Example"/> class.
        /// </summary>
        public PingV1Example(
            IApiClient<PingV1Request, PingV1Response> client)
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
            var request = new PingV1Request();

            var response = await _client
                .Execute(request, cancellationToken)
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
