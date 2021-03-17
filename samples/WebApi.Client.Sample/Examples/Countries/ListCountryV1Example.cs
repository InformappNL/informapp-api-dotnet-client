using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Countries.ListCountry;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Countries
{
    internal class ListCountryV1Example : IExample
    {
        private readonly IApiClient<ListCountryV1Request, ListCountryV1Response> _client;

        public ListCountryV1Example(
            IApiClient<ListCountryV1Request, ListCountryV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            var model = new ListCountryV1Request
            {

            };

            var getResponse = await Get(model, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(getResponse, nameof(getResponse));



            var headResponse = await Head(model, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(headResponse, nameof(headResponse));
        }

        private Task<ApiResponse<ListCountryV1Response>> Get(ListCountryV1Request request, CancellationToken cancellationToken)
        {
            return _client.Execute(request, cancellationToken);
        }

        private Task<ApiResponse<ListCountryV1Response>> Head(ListCountryV1Request model, CancellationToken cancellationToken)
        {
            var request = ApiRequest.Create(model)
                .Head();

            return _client.Execute(request, cancellationToken);
        }
    }
}
