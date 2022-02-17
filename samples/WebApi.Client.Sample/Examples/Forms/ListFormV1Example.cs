using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Forms.ListForm;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.Forms
{
    /// <summary>
    /// Example for list form
    /// </summary>
    public class ListFormV1Example : IExample
    {
        private readonly IApiClient<ListFormV1Request, ListFormV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListFormV1Example"/> class.
        /// </summary>
        public ListFormV1Example(
            IApiClient<ListFormV1Request, ListFormV1Response> client)
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
            var request = new ListFormV1Request
            {
                Sort = new[] { ListFormV1Sort.Name },
                PageNumber = 1,
                PageSize = 10
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
