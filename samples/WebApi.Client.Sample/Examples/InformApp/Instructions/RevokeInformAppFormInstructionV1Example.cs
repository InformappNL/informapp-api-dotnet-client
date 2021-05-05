using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.RevokeInstruction;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.InformApp.Instructions
{
    /// <summary>
    /// Example for revoke instruction
    /// </summary>
    public class RevokeInformAppFormInstructionV1Example : IExample
    {
        private readonly IApiClient<RevokeInformAppFormInstructionV1Request, RevokeInformAppFormInstructionV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RevokeInformAppFormInstructionV1Example"/> class.
        /// </summary>
        public RevokeInformAppFormInstructionV1Example(
            IApiClient<RevokeInformAppFormInstructionV1Request, RevokeInformAppFormInstructionV1Response> client)
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

            var request = new RevokeInformAppFormInstructionV1Request
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
