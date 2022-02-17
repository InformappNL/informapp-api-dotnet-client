using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroups.ListBusinessGroup;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.BusinessGroups
{
    /// <summary>
    /// Example for list business group
    /// </summary>
    public class ListBusinessGroupV1Example : IExample
    {
        private readonly IApiClient<ListBusinessGroupV1Request, ListBusinessGroupV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBusinessGroupV1Example"/> class.
        /// </summary>
        public ListBusinessGroupV1Example(
            IApiClient<ListBusinessGroupV1Request, ListBusinessGroupV1Response> client)
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
            var request = new ListBusinessGroupV1Request
            {
                Sort = new[] { ListBusinessGroupV1Sort.Name },
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
