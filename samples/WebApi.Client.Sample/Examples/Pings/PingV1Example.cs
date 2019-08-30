using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Pings;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Pings
{
    internal class PingV1Example : IExample
    {
        private readonly IApiClient<PingV1Request, PingV1Response> _client;

        public PingV1Example(
            IApiClient<PingV1Request, PingV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            var request = new PingV1Request();

            var response = await _client
                .Execute(request, cancellationToken)
                .ConfigureAwait(WebApiClientSampleProjectSettings.ConfigureAwait);

            Require.NotNull(response, nameof(response));
        }
    }
}
