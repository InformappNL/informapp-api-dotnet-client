using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.RemoveAppGroupMember;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroupMembers
{
    internal class RemoveAppGroupMemberV1Example : IExample
    {
        private readonly IApiClient<RemoveAppGroupMemberV1Request, RemoveAppGroupMemberV1Response> _client;

        public RemoveAppGroupMemberV1Example(
            IApiClient<RemoveAppGroupMemberV1Request, RemoveAppGroupMemberV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var members = new[]
            {
                new RemoveAppGroupMemberV1RequestAppGroupMember
                {
                    AppGroupId = null, // Add app group id
                    AppUserId = null, // Add app user id
                },
                new RemoveAppGroupMemberV1RequestAppGroupMember
                {
                    AppGroupId = null, // Add app group id
                    AppUserId = null, // Add app user id
                },
                // Add more members
            };

            var request = new RemoveAppGroupMemberV1Request
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
