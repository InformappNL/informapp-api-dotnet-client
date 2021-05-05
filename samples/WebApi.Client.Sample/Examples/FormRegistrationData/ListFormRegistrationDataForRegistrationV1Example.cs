using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrations.ListFormRegistration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.FormRegistrationData
{
    /// <summary>
    /// Example for list form registration data
    /// </summary>
    public class ListFormRegistrationDataForRegistrationV1Example : IExample
    {
        private readonly IApiClient<ListFormRegistrationV1Request, ListFormRegistrationV1Response> _registrationClient;

        private readonly IApiClient<ListFormRegistrationDataForRegistrationV1Request, ListFormRegistrationDataForRegistrationV1Response> _registrationDataClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListFormRegistrationDataForRegistrationV1Example"/> class.
        /// </summary>
        public ListFormRegistrationDataForRegistrationV1Example(
            IApiClient<ListFormRegistrationV1Request, ListFormRegistrationV1Response> registrationClient,
            IApiClient<ListFormRegistrationDataForRegistrationV1Request, ListFormRegistrationDataForRegistrationV1Response> registrationDataClient)
        {
            Argument.NotNull(registrationClient, nameof(registrationClient));
            Argument.NotNull(registrationDataClient, nameof(registrationDataClient));

            _registrationClient = registrationClient;

            _registrationDataClient = registrationDataClient;
        }

        /// <summary>
        /// Execute example
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            var registrationId = await GetRegistrationId(cancellationToken)
                .ConfigureAwait(Await.Default);

            if (registrationId.HasValue)
            {
                var select = new[]
                {
                    ListFormRegistrationDataForRegistrationV1Select.All,
                };

                var request = new ListFormRegistrationDataForRegistrationV1Request
                {
                    FormRegistrationId = registrationId,
                    Select = select,
                    PageNumber = 1,
                    PageSize = 50
                };

                var response = await _registrationDataClient.Execute(request, cancellationToken)
                    .ThrowIfFailed()
                    .ConfigureAwait(Await.Default);

                Require.NotNull(response, nameof(response));
            }
        }

        private async Task<Guid?> GetRegistrationId(CancellationToken cancellationToken)
        {
            Guid? registrationId = null;

            var filter = new ListFormRegistrationV1Filter
            {

            };

            var select = new[]
            {
                ListFormRegistrationV1Select.SerialNumber,
            };

            var sort = new[]
            {
                ListFormRegistrationV1Sort.CreateDateDesc,
            };

            var request = new ListFormRegistrationV1Request
            {
                Filter = filter,
                Select = select,
                Sort = sort,
                PageNumber = 1,
                PageSize = 1,
            };

            var response = await _registrationClient
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            if (response.Model.FormRegistrations != null)
            {
                registrationId = response.Model.FormRegistrations
                    .Select(x => x.FormRegistrationId)
                    .FirstOrDefault();
            }

            return registrationId;
        }
    }
}
