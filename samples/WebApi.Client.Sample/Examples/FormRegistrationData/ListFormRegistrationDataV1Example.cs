using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData.ListFormRegistrationData;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationData
{
    internal class ListFormRegistrationDataV1Example : IExample
    {
        private readonly IApiClient<ListFormRegistrationDataV1Request, ListFormRegistrationDataV1Response> _client;

        public ListFormRegistrationDataV1Example(
            IApiClient<ListFormRegistrationDataV1Request, ListFormRegistrationDataV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var request = new ListFormRegistrationDataV1Request
            {
                Sort = new[] { ListFormRegistrationDataV1Sort.SerialNumber },
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
