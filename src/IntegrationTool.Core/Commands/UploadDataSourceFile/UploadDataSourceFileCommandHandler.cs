using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries.CreateStreamFromPath;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Uploaders;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Uploaders.DataSourceFiles;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Commands.UploadDataSourceFile
{
    /// <summary>
    /// Command handler for uploading a datasource file
    /// </summary>
    public class UploadDataSourceFileCommandHandler : ICommandHandler<UploadDataSourceFileCommand, UploadDataSourceFileCommandResult>
    {
        private readonly IQueryHandler<CreateStreamFromPathQuery, CreateStreamFromPathQueryResult> _queryHandler;

        private readonly IUploader<DataSourceFileUploadCommand> _uploader;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadDataSourceFileCommandHandler"/> class.
        /// </summary>
        /// <param name="queryHandler">Injected query handler</param>
        /// <param name="uploader">Injected uploader</param>
        public UploadDataSourceFileCommandHandler(
            IQueryHandler<CreateStreamFromPathQuery, CreateStreamFromPathQueryResult> queryHandler,
            IUploader<DataSourceFileUploadCommand> uploader)
        {
            Argument.NotNull(queryHandler, nameof(queryHandler));
            Argument.NotNull(uploader, nameof(uploader));

            _queryHandler = queryHandler;

            _uploader = uploader;
        }

        /// <summary>
        /// Handles creating the create stream from path query and uploading the datasource file 
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<UploadDataSourceFileCommandResult> Handle(
            UploadDataSourceFileCommand command,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var commandResult = new UploadDataSourceFileCommandResult();

            var query = new CreateStreamFromPathQuery
            {
                Path = command.Path
            };

            using (var queryResult = await _queryHandler
                .Handle(query, cancellationToken)
                .ConfigureAwait(Await.Default))
            {
                var uploadCommand = new DataSourceFileUploadCommand
                {
                    DataSourceId = command.DataSourceId,
                    File = queryResult.File,
                    FileName = queryResult.FileName,
                    Path = queryResult.Path,
                    Size = queryResult.Size,
                    CreationTimeUtc = queryResult.CreationTimeUtc,
                    LastWriteTimeUtc = queryResult.LastWriteTimeUtc,
                };

                _ = await _uploader
                    .Upload(uploadCommand, cancellationToken)
                    .ConfigureAwait(Await.Default);
            }

            commandResult.Result = UploadDataSourceFileCommandResultKind.Success;

            return commandResult;
        }
    }
}
