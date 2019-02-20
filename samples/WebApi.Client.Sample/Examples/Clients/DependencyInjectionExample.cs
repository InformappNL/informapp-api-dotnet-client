using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.GetValues;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Clients
{
    internal class DependencyInjectionExample : IExample
    {
        private readonly IApiClient<GetValuesV1Request, GetValuesV1Response> _client;

        public DependencyInjectionExample(
            IApiClient<GetValuesV1Request, GetValuesV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Run()
        {
            var request = new GetValuesV1Request();

            var response = await _client.Execute(request)
                .ThrowIfFailed();
        }
    }
}
