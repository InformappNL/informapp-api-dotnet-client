using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.AddAppGroupMember;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroupMembers
{
    internal class AddAppGroupMemberV1Example : IExample
    {
        private readonly IApiClient<AddAppGroupMemberV1Request, AddAppGroupMemberV1Response> _client;

        public AddAppGroupMemberV1Example(
            IApiClient<AddAppGroupMemberV1Request, AddAppGroupMemberV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            var members = new[]
            {
                new AddAppGroupMemberV1RequestAppGroupMember
                {
                    AppGroupId = null, // Add app group id
                    AppUserId = null, // Add app user id
                },
                new AddAppGroupMemberV1RequestAppGroupMember
                {
                    AppGroupId = null, // Add app group id
                    AppUserId = null, // Add app user id
                },
                // Add more members
            };

            var request = new AddAppGroupMemberV1Request
            {
                Members = members
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(WebApiClientSampleProjectSettings.ConfigureAwait);

            Require.NotNull(response, nameof(response));
        }
    }
}
