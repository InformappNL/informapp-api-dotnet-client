using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.ListDataSource;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.DataSources
{
    /// <summary>
    /// Example for list data source
    /// </summary>
    public class ListDataSourceV1Example : IExample
    {
        private readonly IApiClient<ListDataSourceV1Request, ListDataSourceV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListDataSourceV1Example"/> class.
        /// </summary>
        public ListDataSourceV1Example(
            IApiClient<ListDataSourceV1Request, ListDataSourceV1Response> client)
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
            var request = new ListDataSourceV1Request
            {
                Sort = new[] { ListDataSourceV1Sort.Name },
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
