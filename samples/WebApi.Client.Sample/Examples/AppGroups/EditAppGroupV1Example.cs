using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.EditAppGroup;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroups
{
    internal class EditAppGroupV1Example : IExample
    {
        private readonly IApiClient<EditAppGroupV1Request, EditAppGroupV1Response> _client;

        public EditAppGroupV1Example(
            IApiClient<EditAppGroupV1Request, EditAppGroupV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var request = new EditAppGroupV1Request
            {
                AppGroupId = Guid.Empty, // App group id here
                Name = null,
                Description = null
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(WebApiClientSampleProjectSettings.ConfigureAwait);

            Require.NotNull(response, nameof(response));
        }
    }
}
