using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Clients;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.GetValues;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Clients
{
    /// <summary>
    /// Example using the api client facade
    /// </summary>
    internal class ApiClientExample : IExample
    {
        public ApiClientExample()
        {

        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var client = new ApiClient<GetValuesV1Request, GetValuesV1Response>();

            var request = ApiRequest.Create(new GetValuesV1Request());

            var response = await client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(WebApiClientSampleProjectSettings.ConfigureAwait);

            Require.NotNull(response, nameof(response));
        }
    }
}
