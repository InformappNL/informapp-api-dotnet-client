using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.BusinessGroups.ListBusinessGroup;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.BusinessGroups
{
    internal class ListBusinessGroupV1Example : IExample
    {
        private readonly IApiClient<ListBusinessGroupV1Request, ListBusinessGroupV1Response> _client;

        public ListBusinessGroupV1Example(
            IApiClient<ListBusinessGroupV1Request, ListBusinessGroupV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run()
        {
            var request = new ListBusinessGroupV1Request
            {
                Sort = new[] { ListBusinessGroupV1Sort.Name },
                PageNumber = 1,
                PageSize = 50
            };

            var response = await _client.Execute(request)
                .ThrowIfFailed();
        }
    }
}
