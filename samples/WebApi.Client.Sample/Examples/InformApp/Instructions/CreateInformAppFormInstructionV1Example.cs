﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.CreateInstruction;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.InformApp.Instructions
{
    /// <summary>
    /// Example for create form instruction
    /// </summary>
    public class CreateInformAppFormInstructionV1Example : IExample
    {
        private readonly IApiClient<CreateInformAppFormInstructionV1Request, CreateInformAppFormInstructionV1Response> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateInformAppFormInstructionV1Example"/> class.
        /// </summary>
        public CreateInformAppFormInstructionV1Example(
            IApiClient<CreateInformAppFormInstructionV1Request, CreateInformAppFormInstructionV1Response> client)
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

            var recipients = new[]
            {
                "58e213fcf1396c37ce86ba1a",
            };

#pragma warning disable IDE0028 // Simplify collection initialization
            var formData = new Dictionary<string, object>(StringComparer.Ordinal);
#pragma warning restore IDE0028 // Simplify collection initialization

            formData.Add("newText", "test 123");
            formData.Add("date", "2021-03-10");
            formData.Add("lookup", "Option 2");
            formData.Add("lookupMultiple", new[] { "Option 2", "Option 4" });
            formData.Add("radio", "Option 2");

            var subform = new Dictionary<string, object>();

            formData.Add("subform", new[] { subform });

            subform.Add("text", "test 456");
            subform.Add("date", "2018-12-24");

            var request = new CreateInformAppFormInstructionV1Request
            {
                FormId = formId,
                Message = "Sample instruction",
                InformationDate = DateTimeOffset.Now.AddDays(7),
                FormData = formData,
                PublishDate = DateTimeOffset.Now,
                Recipients = recipients,
            };

            var response = await _client.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
