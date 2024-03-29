﻿using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.GetAppGroup;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppGroups.ListAppGroup;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.AppGroups
{
    /// <summary>
    /// Example for get app group
    /// </summary>
    public class GetAppGroupV1Example : IExample
    {
        private readonly IApiClient<ListAppGroupV1Request, ListAppGroupV1Response> _listClient;

        private readonly IApiClient<GetAppGroupV1Request, GetAppGroupV1Response> _getClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAppGroupV1Example"/> class.
        /// </summary>
        public GetAppGroupV1Example(
            IApiClient<ListAppGroupV1Request, ListAppGroupV1Response> listClient,
            IApiClient<GetAppGroupV1Request, GetAppGroupV1Response> getClient)
        {
            Argument.NotNull(listClient, nameof(listClient));
            Argument.NotNull(getClient, nameof(getClient));

            _listClient = listClient;

            _getClient = getClient;
        }

        /// <summary>
        /// Execute example
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            // Obtain an app group id using a list request
            var appGroupId = await GetAppGroupId(cancellationToken)
                .ConfigureAwait(Await.Default);

            if (appGroupId.HasValue == true)
            {
                // Use it to execute a GET and HEAD request
                await Get(appGroupId, cancellationToken)
                    .ConfigureAwait(Await.Default);

                await Head(appGroupId, cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
        }

        private async Task Get(Guid? appGroupId, CancellationToken cancellationToken)
        {
            var request = new GetAppGroupV1Request
            {
                AppGroupId = appGroupId
            };

            var response = await _getClient.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }

        private async Task Head(Guid? appGroupId, CancellationToken cancellationToken)
        {
            var request = ApiRequest.Create(new GetAppGroupV1Request
            {
                AppGroupId = appGroupId
            });

            request.Context = new RequestContext
            {
                Method = HttpMethod.Head
            };

            var response = await _getClient.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }

        private async Task<Guid?> GetAppGroupId(CancellationToken cancellationToken)
        {
            var request = new ListAppGroupV1Request
            {
                Sort = new[] { ListAppGroupV1Sort.Name },
                PageNumber = 1,
                PageSize = 1
            };

            var response = await _listClient.Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            if (response.IsSuccessful == true && response.Model.Total > 1)
            {
                var appGroupId = response.Model.AppGroups[0].AppGroupId;

                return appGroupId;
            }

            return null;
        }
    }
}
