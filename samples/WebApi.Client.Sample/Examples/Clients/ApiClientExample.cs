using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Clients;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.ListValues;
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
            var client = new ApiClient<ListValuesV1Request, ListValuesV1Response>();

            var request = ApiRequest.Create(new ListValuesV1Request());

            var response = await client
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }
    }
}
