using Informapp.InformSystem.IntegrationTool.Core.Queries;
using Informapp.InformSystem.IntegrationTool.Core.Queries.FileNeedsUpload;
using Informapp.InformSystem.WebApi.Client.Decorators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Uploaders
{
    /// <summary>
    /// Decorator class for <see cref="IUploader{TCommand}"/> to check if an upload is needed
    /// </summary>
    /// <typeparam name="TCommand">Type of command</typeparam>
    public class CheckUploadNeededUploaderDecorator<TCommand> : Decorator<IUploader<TCommand>>,
        IUploader<TCommand>

        where TCommand : class, IUploadCommand
    {
        private readonly IUploader<TCommand> _uploader;

        private readonly IQueryHandler<FileNeedsUploadQuery, FileNeedsUploadQueryResult> _queryHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckUploadNeededUploaderDecorator{TCommand}"/> class
        /// </summary>
        /// <param name="uploader">Injected file uploader</param>
        /// <param name="queryHandler">Injected query handler</param>
        public CheckUploadNeededUploaderDecorator(
            IUploader<TCommand> uploader,
            IQueryHandler<FileNeedsUploadQuery, FileNeedsUploadQueryResult> queryHandler) : base(uploader)
        {
            Argument.NotNull(uploader, nameof(uploader));
            Argument.NotNull(queryHandler, nameof(queryHandler));

            _uploader = uploader;

            _queryHandler = queryHandler;
        }

        /// <summary>
        /// Uploads the file if the check finds that upload is needed
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public async Task<IUploadResult> Upload(TCommand command, CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var query = new FileNeedsUploadQuery
            {
                File = command.File,
                FileName = command.FileName,
                Path = command.Path,
                Size = command.Size,
                CreationTimeUtc = command.CreationTimeUtc,
                LastWriteTimeUtc = command.LastWriteTimeUtc,
            };

            var queryResult = await _queryHandler
                .Handle(query, cancellationToken)
                .ConfigureAwait(Await.Default);

            bool upload = queryResult.FileNeedsUpload;

            if (upload == true)
            {
                return await _uploader
                    .Upload(command, cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
            else
            {
                var uploadResult = new UploadResult
                {
                    Success = true,
                };

                return uploadResult;
            }
        }
    }
}
