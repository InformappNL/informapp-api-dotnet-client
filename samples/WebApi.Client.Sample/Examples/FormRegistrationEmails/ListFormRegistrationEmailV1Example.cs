using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmails.ListFormRegistrationEmail;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationEmails
{
    internal class ListFormRegistrationEmailV1Example : IExample
    {
        private readonly IApiClient<ListFormRegistrationEmailV1Request, ListFormRegistrationEmailV1Response> _client;

        public ListFormRegistrationEmailV1Example(
            IApiClient<ListFormRegistrationEmailV1Request, ListFormRegistrationEmailV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            var request = new ListFormRegistrationEmailV1Request
            {
                Sort = new[] { ListFormRegistrationEmailV1Sort.SerialNumber },
                PageNumber = 1,
                PageSize = 50
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(WebApiClientSampleProjectSettings.ConfigureAwait);

            Require.NotNull(response, nameof(response));
        }
    }
}
