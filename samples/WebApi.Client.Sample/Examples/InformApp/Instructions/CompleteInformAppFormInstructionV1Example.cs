using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.CompleteInstruction;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.InformApp.Instructions
{
    internal class CompleteInformAppFormInstructionV1Example : IExample
    {
        private readonly IApiClient<CompleteInformAppFormInstructionV1Request, CompleteInformAppFormInstructionV1Response> _client;

        public CompleteInformAppFormInstructionV1Example(
            IApiClient<CompleteInformAppFormInstructionV1Request, CompleteInformAppFormInstructionV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var formId = Guid.Parse("2fa22553-0587-459b-b81f-b474c448a3f3");
            var instructionId = "6048a32d3067e05ceeeb1dea";

            var request = new CompleteInformAppFormInstructionV1Request
            {
                FormId = formId,
                InstructionId = instructionId,
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
