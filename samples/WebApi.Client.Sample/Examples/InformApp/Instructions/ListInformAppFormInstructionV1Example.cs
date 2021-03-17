using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.ListInstruction;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.InformApp.Instructions
{
    internal class ListInformAppFormInstructionV1Example : IExample
    {
        private readonly IApiClient<ListInformAppFormInstructionV1Request, ListInformAppFormInstructionV1Response> _client;

        public ListInformAppFormInstructionV1Example(
            IApiClient<ListInformAppFormInstructionV1Request, ListInformAppFormInstructionV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

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
