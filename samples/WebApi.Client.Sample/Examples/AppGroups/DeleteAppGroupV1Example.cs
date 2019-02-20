using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.DeleteAppGroup;
using System;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroups
{
    internal class DeleteAppGroupV1Example : IExample
    {
        private readonly IApiClient<DeleteAppGroupV1Request, DeleteAppGroupV1Response> _client;

        public DeleteAppGroupV1Example(
            IApiClient<DeleteAppGroupV1Request, DeleteAppGroupV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run()
        {
            var request = new DeleteAppGroupV1Request
            {
                AppGroupId = Guid.Empty // App group id here
            };

            var response = await _client.Execute(request)
                .ThrowIfFailed();
        }
    }
}
