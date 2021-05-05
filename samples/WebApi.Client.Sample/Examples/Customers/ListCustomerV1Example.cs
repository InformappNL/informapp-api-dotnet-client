using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Customers.ListCustomer;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Customers
{
    /// <summary>
    /// Example for list customer
    /// </summary>
    public class ListCustomerV1Example : IExample
    {
        private readonly IApiClient<ListCustomerV1Request, ListCustomerV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListCustomerV1Example"/> class.
        /// </summary>
        public ListCustomerV1Example(
            IApiClient<ListCustomerV1Request, ListCustomerV1Response> client)
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
            var request = new ListCustomerV1Request
            {
                Sort = new[] { ListCustomerV1Sort.Name },
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
