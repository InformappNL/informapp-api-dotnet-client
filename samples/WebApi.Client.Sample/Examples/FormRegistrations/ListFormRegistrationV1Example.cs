using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrations.ListFormRegistration;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.FormRegistrations
{
    /// <summary>
    /// Example for list form registration
    /// </summary>
    public class ListFormRegistrationV1Example : IExample
    {
        private readonly IApiClient<ListFormRegistrationV1Request, ListFormRegistrationV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListFormRegistrationV1Example"/> class.
        /// </summary>
        public ListFormRegistrationV1Example(
            IApiClient<ListFormRegistrationV1Request, ListFormRegistrationV1Response> client)
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
            var request = new ListFormRegistrationV1Request
            {
                Sort = new[] { ListFormRegistrationV1Sort.SerialNumber },
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
