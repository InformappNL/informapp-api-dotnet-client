using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.RemoveAppGroupMember;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.AppGroupMembers
{
    /// <summary>
    /// Example for remote app group member
    /// </summary>
    public class RemoveAppGroupMemberV1Example : IExample
    {
        private readonly IApiClient<RemoveAppGroupMemberV1Request, RemoveAppGroupMemberV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveAppGroupMemberV1Example"/> class.
        /// </summary>
        public RemoveAppGroupMemberV1Example(
            IApiClient<RemoveAppGroupMemberV1Request, RemoveAppGroupMemberV1Response> client)
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
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
