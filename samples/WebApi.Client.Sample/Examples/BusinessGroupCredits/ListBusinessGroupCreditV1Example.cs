using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroupCredits.ListBusinessGroupCredit;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.BusinessGroupCredits
{
    internal class ListBusinessGroupCreditCreditV1Example : IExample
    {
        private readonly IApiClient<ListBusinessGroupCreditV1Request, ListBusinessGroupCreditV1Response> _client;

        public ListBusinessGroupCreditCreditV1Example(
            IApiClient<ListBusinessGroupCreditV1Request, ListBusinessGroupCreditV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var request = new ListBusinessGroupCreditV1Request
            {
                Sort = new[] { ListBusinessGroupCreditV1Sort.Name },
                PageNumber = 1,
                PageSize = 50
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
