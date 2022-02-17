using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Requests;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Http;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.GetAppUser;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.AppUsers.ListAppUser;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.AppUsers
{
    /// <summary>
    /// Example for get app user
    /// </summary>
    public class GetAppUserV1Example : IExample
    {
        private readonly IApiClient<ListAppUserV1Request, ListAppUserV1Response> _listClient;

        private readonly IApiClient<GetAppUserV1Request, GetAppUserV1Response> _getClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAppUserV1Example"/> class.
        /// </summary>
        public GetAppUserV1Example(
            IApiClient<ListAppUserV1Request, ListAppUserV1Response> listClient,
            IApiClient<GetAppUserV1Request, GetAppUserV1Response> getClient)
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
            // Obtain an app user id using a list request
            var AppUserId = await GetAppUserId(cancellationToken)
                .ConfigureAwait(Await.Default);

            if (AppUserId.HasValue == true)
            {
                // Use it to execute a GET and HEAD request
                await Get(AppUserId, cancellationToken)
                    .ConfigureAwait(Await.Default);

                await Head(AppUserId, cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
        }

        private async Task Get(Guid? appUserId, CancellationToken cancellationToken)
        {
            var request = new GetAppUserV1Request
            {
                AppUserId = appUserId
            };

            var response = await _getClient
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }

        private async Task Head(Guid? appUserId, CancellationToken cancellationToken)
        {
            var request = ApiRequest.Create(new GetAppUserV1Request
            {
                AppUserId = appUserId
            });

            request.Context = new RequestContext
            {
                Method = HttpMethod.Head
            };

            var response = await _getClient
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            Require.NotNull(response, nameof(response));
        }

        private async Task<Guid?> GetAppUserId(CancellationToken cancellationToken)
        {
            var request = new ListAppUserV1Request
            {
                Sort = new[] { ListAppUserV1Sort.Email },
                PageNumber = 1,
                PageSize = 1
            };

            var response = await _listClient
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            if (response.IsSuccessful == true && response.Model.AppUsers.Count > 0)
            {
                var AppUserId = response.Model.AppUsers[0].AppUserId;

                return AppUserId;
            }

            return null;
        }
    }
}
