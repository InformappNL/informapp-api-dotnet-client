using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.CreateAppGroup;
using System;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroups
{
    internal class CreateAppGroupV1Example : IExample
    {
        private readonly IApiClient<CreateAppGroupV1Request, CreateAppGroupV1Response> _client;

        public CreateAppGroupV1Example(
            IApiClient<CreateAppGroupV1Request, CreateAppGroupV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run()
        {
            var request = new CreateAppGroupV1Request
            {
                Name = "Example AppGroup",
                Description = "Created by API example",
                BusinessGroupId = Guid.Empty // Business group id here
            };

            var response = await _client.Execute(request)
                .ThrowIfFailed();
        }
    }
}
