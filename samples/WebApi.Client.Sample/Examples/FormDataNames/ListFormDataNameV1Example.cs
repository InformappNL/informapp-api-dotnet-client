using ConnectedDevelopment.InformSystem.WebApi.Client.Clients;
using ConnectedDevelopment.InformSystem.WebApi.Client.Responses;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Requires;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormDataNames;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Forms.ListForm;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample.Examples.FormDataNames
{
    /// <summary>
    /// Example for list form data name
    /// </summary>
    public class ListFormDataNameV1Example : IExample
    {
        private readonly IApiClient<ListFormV1Request, ListFormV1Response> _formClient;

        private readonly IApiClient<ListFormDataNameV1Request, ListFormDataNameV1Response> _formDataNameClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListFormDataNameV1Example"/> class.
        /// </summary>
        public ListFormDataNameV1Example(
            IApiClient<ListFormV1Request, ListFormV1Response> formClient,
            IApiClient<ListFormDataNameV1Request, ListFormDataNameV1Response> formDataNameClient)
        {
            Argument.NotNull(formClient, nameof(formClient));
            Argument.NotNull(formDataNameClient, nameof(formDataNameClient));

            _formClient = formClient;

            _formDataNameClient = formDataNameClient;
        }

        /// <summary>
        /// Execute example
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            var formId = await GetFormId(cancellationToken)
                .ConfigureAwait(Await.Default);

            if (formId.HasValue)
            {
                var select = new[]
                {
                    ListFormDataNameV1Select.All,
                };

                var request = new ListFormDataNameV1Request
                {
                    FormId = formId,
                    Select = select,
                    PageNumber = 1,
                    PageSize = 50
                };

                var response = await _formDataNameClient.Execute(request, cancellationToken)
                    .ThrowIfFailed()
                    .ConfigureAwait(Await.Default);

                Require.NotNull(response, nameof(response));
            }
        }

        private async Task<Guid?> GetFormId(CancellationToken cancellationToken)
        {
            Guid? registrationId = null;

            var filter = new ListFormV1Filter
            {

            };

            var select = new[]
            {
                ListFormV1Select.Name,
            };

            var sort = new[]
            {
                ListFormV1Sort.CreateDateDesc,
            };

            var request = new ListFormV1Request
            {
                Filter = filter,
                Select = select,
                Sort = sort,
                PageNumber = 1,
                PageSize = 1,
            };

            var response = await _formClient
                .Execute(request, cancellationToken)
                .ThrowIfFailed()
                .ConfigureAwait(Await.Default);

            if (response.Model.Forms != null)
            {
                registrationId = response.Model.Forms
                    .Select(x => x.FormId)
                    .FirstOrDefault();
            }

            return registrationId;
        }
    }
}
