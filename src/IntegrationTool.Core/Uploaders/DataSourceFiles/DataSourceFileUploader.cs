using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.UploadDataSource;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Uploaders.DataSourceFiles
{
    /// <summary>
    /// Datasource file uploader
    /// </summary>
    public class DataSourceFileUploader : IUploader<DataSourceFileUploadCommand>
    {
        private readonly IApiClient<UploadDataSourceV1Request, UploadDataSourceV1Response> _apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceFileUploader"/> class
        /// </summary>
        /// <param name="apiClient">Injected api client</param>
        public DataSourceFileUploader(
            IApiClient<UploadDataSourceV1Request, UploadDataSourceV1Response> apiClient)
        {
            Argument.NotNull(apiClient, nameof(apiClient));

            _apiClient = apiClient;
        }

        /// <summary>
        /// Uploads the file that is set up for the datasource
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<IUploadResult> Upload(
            DataSourceFileUploadCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var uploadResult = new UploadResult();

            using (var request = new UploadDataSourceV1Request
            {
                DataSourceId = command.DataSourceId,
                File = command.File,
                FileName = command.FileName,
                Size = command.Size,
            })
            {
                var response = await _apiClient
                    .Execute(request, cancellationToken)
                    .ConfigureAwait(Await.Default);

                uploadResult.Success = response.IsSuccessful;

                request.File = null;
            }

            return uploadResult;
        }
    }
}
