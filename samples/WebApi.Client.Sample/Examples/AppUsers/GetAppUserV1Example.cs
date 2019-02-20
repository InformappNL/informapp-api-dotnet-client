using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.GetAppUser;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.ListAppUser;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppUsers
{
    internal class GetAppUserV1Example : IExample
    {
        private readonly IApiClient<ListAppUserV1Request, ListAppUserV1Response> _listClient;

        private readonly IApiClient<GetAppUserV1Request, GetAppUserV1Response> _getClient;

        public GetAppUserV1Example(
            IApiClient<ListAppUserV1Request, ListAppUserV1Response> listClient,
            IApiClient<GetAppUserV1Request, GetAppUserV1Response> getClient)
        {
            Argument.NotNull(listClient, nameof(listClient));
            Argument.NotNull(getClient, nameof(getClient));

            _listClient = listClient;

            _getClient = getClient;
        }

        public async Task Run()
        {
            // Obtain an app user id using a list request
            var AppUserId = await GetAppUserId();

            if (AppUserId.HasValue == true)
            {
                // Use it to execute a GET and HEAD request
                await Get(AppUserId);

                await Head(AppUserId);
            }
        }

        private async Task Get(Guid? appUserId)
        {
            var request = new GetAppUserV1Request
            {
                AppUserId = appUserId
            };

            var response = await _getClient.Execute(request)
                .ThrowIfFailed();
        }

        private async Task Head(Guid? appUserId)
        {
            var request = ApiRequest.Create(new GetAppUserV1Request
            {
                AppUserId = appUserId
            });

            request.Context = new RequestContext
            {
                Method = HttpMethod.Head
            };

            var response = await _getClient.Execute(request)
                .ThrowIfFailed();
        }

        private async Task<Guid?> GetAppUserId()
        {
            var request = new ListAppUserV1Request
            {
                Sort = new[] { ListAppUserV1Sort.Email },
                PageNumber = 1,
                PageSize = 1
            };

            var response = await _listClient.Execute(request)
                .ThrowIfFailed();

            if (response.IsSuccessful == true && response.Model.Total > 1)
            {
                var AppUserId = response.Model.AppUsers.First().AppUserId;

                return AppUserId;
            }

            return null;
        }
    }
}
