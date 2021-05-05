using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.EditAppGroup;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroups
{
    /// <summary>
    /// Example for edit app group
    /// </summary>
    public class EditAppGroupV1Example : IExample
    {
        private readonly IApiClient<EditAppGroupV1Request, EditAppGroupV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditAppGroupV1Example"/> class.
        /// </summary>
        public EditAppGroupV1Example(
            IApiClient<EditAppGroupV1Request, EditAppGroupV1Response> client)
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
            var request = new EditAppGroupV1Request
            {
                AppGroupId = Guid.Empty, // App group id here
                Name = null,
                Description = null
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
