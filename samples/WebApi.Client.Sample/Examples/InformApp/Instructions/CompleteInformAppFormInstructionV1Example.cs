using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.CompleteInstruction;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.InformApp.Instructions
{
    /// <summary>
    /// Example for complete form instruction
    /// </summary>
    public class CompleteInformAppFormInstructionV1Example : IExample
    {
        private readonly IApiClient<CompleteInformAppFormInstructionV1Request, CompleteInformAppFormInstructionV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompleteInformAppFormInstructionV1Example"/> class.
        /// </summary>
        public CompleteInformAppFormInstructionV1Example(
            IApiClient<CompleteInformAppFormInstructionV1Request, CompleteInformAppFormInstructionV1Response> client)
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
