using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Clients;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.GetValues;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Clients
{
    /// <summary>
    /// Example using the factory
    /// </summary>
    internal class ApiClientFactoryExample : IExample
    {
        public ApiClientFactoryExample()
        {

        }

        public async Task Run()
        {
            var factory = new ApiClientFactory();

            var client = factory.Create<GetValuesV1Request, GetValuesV1Response>();

            var request = ApiRequest.Create(new GetValuesV1Request());

            var response = await client.Execute(request)
                .ThrowIfFailed();
        }
    }
}
