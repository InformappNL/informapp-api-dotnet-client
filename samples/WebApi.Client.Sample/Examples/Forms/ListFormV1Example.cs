using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Forms.ListForm;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Forms
{
    internal class ListFormV1Example : IExample
    {
        private readonly IApiClient<ListFormV1Request, ListFormV1Response> _client;

        public ListFormV1Example(
            IApiClient<ListFormV1Request, ListFormV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            var request = new ListFormV1Request
            {
                Sort = new[] { ListFormV1Sort.Name },
                PageNumber = 1,
                PageSize = 10
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(WebApiClientSampleProjectSettings.ConfigureAwait);

            Require.NotNull(response, nameof(response));
        }
    }
}
