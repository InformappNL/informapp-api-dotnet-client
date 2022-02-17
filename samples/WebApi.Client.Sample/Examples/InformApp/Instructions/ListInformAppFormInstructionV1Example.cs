using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.ListInstruction;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.InformApp.Instructions
{
    /// <summary>
    /// Example for list form instruction
    /// </summary>
    public class ListInformAppFormInstructionV1Example : IExample
    {
        private readonly IApiClient<ListInformAppFormInstructionV1Request, ListInformAppFormInstructionV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListInformAppFormInstructionV1Example"/> class.
        /// </summary>
        public ListInformAppFormInstructionV1Example(
            IApiClient<ListInformAppFormInstructionV1Request, ListInformAppFormInstructionV1Response> client)
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
            var formId = Guid.Parse("2fa22553-0587-459b-b81f-b474c448a3f3");

            var filter = new ListInformAppFormInstructionV1Filter
            {

            };

            var request = new ListInformAppFormInstructionV1Request
            {
                FormId = formId,
                Filter = filter,
                Sort = ListInformAppFormInstructionV1Sort.CreateDateDesc,
                PageNumber = 1,
                PageSize = 100
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
