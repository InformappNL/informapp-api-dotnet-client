using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationEmails.ListFormRegistrationEmail;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationEmails
{
    /// <summary>
    /// Example for list form registration email
    /// </summary>
    public class ListFormRegistrationEmailV1Example : IExample
    {
        private readonly IApiClient<ListFormRegistrationEmailV1Request, ListFormRegistrationEmailV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListFormRegistrationEmailV1Example"/> class.
        /// </summary>
        public ListFormRegistrationEmailV1Example(
            IApiClient<ListFormRegistrationEmailV1Request, ListFormRegistrationEmailV1Response> client)
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
            var request = new ListFormRegistrationEmailV1Request
            {
                Sort = new[] { ListFormRegistrationEmailV1Sort.SerialNumber },
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
