using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.ListAppUser;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppUsers
{
    /// <summary>
    /// Example for list app user
    /// </summary>
    public class ListAppUserV1Example : IExample
    {
        private readonly IApiClient<ListAppUserV1Request, ListAppUserV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListAppUserV1Example"/> class.
        /// </summary>
        public ListAppUserV1Example(
            IApiClient<ListAppUserV1Request, ListAppUserV1Response> client)
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
            var request = new ListAppUserV1Request
            {
                Sort = new[] { ListAppUserV1Sort.Email },
                PageNumber = 1,
                PageSize = 50
            };

            var response = await _client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
