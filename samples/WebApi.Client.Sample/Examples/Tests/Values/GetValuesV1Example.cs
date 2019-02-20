using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.GetValues;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Values
{
    internal class GetValuesV1Example : IExample
    {
        private readonly IApiClient<GetValuesV1Request, GetValuesV1Response> _client;

        public GetValuesV1Example(
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
