using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationStats.ListFormRegistrationStats;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationStats
{
    internal class ListFormRegistrationStatsV1Example : IExample
    {
        private readonly IApiClient<ListFormRegistrationStatsV1Request, ListFormRegistrationStatsV1Response> _client;

        public ListFormRegistrationStatsV1Example(
            IApiClient<ListFormRegistrationStatsV1Request, ListFormRegistrationStatsV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var request = new ListFormRegistrationStatsV1Request
            {
                Sort = new[] { ListFormRegistrationStatsV1Sort.RegistrationCount },
                PageNumber = 1,
                PageSize = 10
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
