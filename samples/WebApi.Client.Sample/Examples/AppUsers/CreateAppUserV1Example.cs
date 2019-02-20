using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.CreateAppUser;
using System;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppUsers
{
    internal class CreateAppUserV1Example : IExample
    {
        private readonly IApiClient<CreateAppUserV1Request, CreateAppUserV1Response> _client;

        public CreateAppUserV1Example(
            IApiClient<CreateAppUserV1Request, CreateAppUserV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run()
        {
            var request = new CreateAppUserV1Request
            {
                Email = null,
                CustomerId = Guid.Empty // Customer id here
            };

            var response = await _client.Execute(request)
                .ThrowIfFailed();
        }
    }
}
