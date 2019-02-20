﻿using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Models.Http;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.GetAppGroup;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.ListAppGroup;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.AppGroups
{
    internal class GetAppGroupV1Example : IExample
    {
        private readonly IApiClient<ListAppGroupV1Request, ListAppGroupV1Response> _listClient;

        private readonly IApiClient<GetAppGroupV1Request, GetAppGroupV1Response> _getClient;

        public GetAppGroupV1Example(
            IApiClient<ListAppGroupV1Request, ListAppGroupV1Response> listClient,
            IApiClient<GetAppGroupV1Request, GetAppGroupV1Response> getClient)
        {
            Argument.NotNull(listClient, nameof(listClient));
            Argument.NotNull(getClient, nameof(getClient));

            _listClient = listClient;

            _getClient = getClient;
        }

        public async Task Run()
        {
            // Obtain an app group id using a list request
            var appGroupId = await GetAppGroupId();

            if (appGroupId.HasValue == true)
            {
                // Use it to execute a GET and HEAD request
                await Get(appGroupId);

                await Head(appGroupId);
            }
        }

        private async Task Get(Guid? appGroupId)
        {
            var request = new GetAppGroupV1Request
            {
                AppGroupId = appGroupId
            };

            var response = await _getClient.Execute(request)
                .ThrowIfFailed();
        }

        private async Task Head(Guid? appGroupId)
        {
            var request = ApiRequest.Create(new GetAppGroupV1Request
            {
                AppGroupId = appGroupId
            });

            request.Context = new RequestContext
            {
                Method = HttpMethod.Head
            };

            var response = await _getClient.Execute(request)
                .ThrowIfFailed();
        }

        private async Task<Guid?> GetAppGroupId()
        {
            var request = new ListAppGroupV1Request
            {
                Sort = new[] { ListAppGroupV1Sort.Name },
                PageNumber = 1,
                PageSize = 1
            };

            var response = await _listClient.Execute(request)
                .ThrowIfFailed();

            if (response.IsSuccessful == true && response.Model.Total > 1)
            {
                var appGroupId = response.Model.AppGroups.First().AppGroupId;

                return appGroupId;
            }

            return null;
        }
    }
}
