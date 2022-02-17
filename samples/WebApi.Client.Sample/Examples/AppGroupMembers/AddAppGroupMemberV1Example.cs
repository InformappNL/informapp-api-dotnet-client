using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroupMembers.AddAppGroupMember;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.AppGroupMembers
{
    /// <summary>
    /// Example for add app group member
    /// </summary>
    public class AddAppGroupMemberV1Example : IExample
    {
        private readonly IApiClient<AddAppGroupMemberV1Request, AddAppGroupMemberV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddAppGroupMemberV1Example"/> class.
        /// </summary>
        public AddAppGroupMemberV1Example(
            IApiClient<AddAppGroupMemberV1Request, AddAppGroupMemberV1Response> client)
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
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
