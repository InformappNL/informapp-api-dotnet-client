using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.CreateAppGroup;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.AppGroups
{
    /// <summary>
    /// Example for create app group
    /// </summary>
    public class CreateAppGroupV1Example : IExample
    {
        private readonly IApiClient<CreateAppGroupV1Request, CreateAppGroupV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAppGroupV1Example"/> class.
        /// </summary>
        public CreateAppGroupV1Example(
            IApiClient<CreateAppGroupV1Request, CreateAppGroupV1Response> client)
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
            var request = new CreateAppGroupV1Request
            {
                Name = "Example AppGroup",
                Description = "Created by API example",
                BusinessGroupId = Guid.Empty // Business group id here
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
