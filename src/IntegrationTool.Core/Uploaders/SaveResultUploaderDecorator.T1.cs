using ConnectedDevelopment.InformSystem.IntegrationTool.Core.DataContexts;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries.HashFile;
using ConnectedDevelopment.InformSystem.WebApi.Client.DateTimeProviders;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Uploaders
{
    /// <summary>
    /// Decorator class for <see cref="IUploader{TCommand}"/> to save the result of the completed or failed upload
    /// </summary>
    /// <typeparam name="TCommand">Type of command</typeparam>
    public class SaveResultUploaderDecorator<TCommand> : Decorator<IUploader<TCommand>>,
        IUploader<TCommand>

        where TCommand : class, IUploadCommand
    {
        private readonly IUploader<TCommand> _uploader;

        private readonly IDataContext _dataContext;

        private readonly IDateTimeProvider _dateTimeProvider;

        private readonly IQueryHandler<HashFileQuery, HashFileQueryResult> _hashFileQueryHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveResultUploaderDecorator{TCommand}"/> class
        /// </summary>
        /// <param name="uploader">Injected uploader</param>
        /// <param name="dataContext">Injected data context</param>
        /// <param name="dateTimeProvider">Injected date time provider</param>
        /// <param name="hashFileQueryHandler">Injected hash file query handler</param>
        public SaveResultUploaderDecorator(
            IUploader<TCommand> uploader,
            IDataContext dataContext,
            IDateTimeProvider dateTimeProvider,
            IQueryHandler<HashFileQuery, HashFileQueryResult> hashFileQueryHandler) : base(uploader)
        {
            Argument.NotNull(uploader, nameof(uploader));
            Argument.NotNull(dataContext, nameof(dataContext));
            Argument.NotNull(dateTimeProvider, nameof(dateTimeProvider));
            Argument.NotNull(hashFileQueryHandler, nameof(hashFileQueryHandler));

            _uploader = uploader;

            _dataContext = dataContext;

            _dateTimeProvider = dateTimeProvider;

            _hashFileQueryHandler = hashFileQueryHandler;
        }

        /// <summary>
        /// Saves the result of the upload
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The upload result</returns>
        public async Task<IUploadResult> Upload(TCommand command, CancellationToken cancellationToken)
        {
            Argument.NotNull(command, nameof(command));

            var uploadResult = await _uploader
                .Upload(command, cancellationToken)
                .ConfigureAwait(Await.Default);

            var now = _dateTimeProvider.UtcNow;

            var file = _dataContext.DataSources
                .Where(x => string.Equals(command.Path, x.Path, StringComparison.OrdinalIgnoreCase) == true)
                .FirstOrDefault();

            if (file == null)
            {
                file = new DataSource
                {
                    Path = command.Path,
                    Attempts = 0,
                };

                _dataContext.DataSources.Add(file);
            }

            if (file.Attempts.HasValue == false)
            {
                file.Attempts = 0;
            }

            if (uploadResult.Success == true)
            {
                var query = new HashFileQuery
                {
                    File = command.File,
                };

                var queryResult = await _hashFileQueryHandler
                    .Handle(query, cancellationToken)
                    .ConfigureAwait(Await.Default);

                file.UploadNeeded = false;
                file.LastUploadDate = now;
                file.Size = command.Size;
                file.Hash = queryResult.Hash;
                file.CreationTimeUtc = command.CreationTimeUtc;
                file.LastWriteTimeUtc = command.LastWriteTimeUtc;
                file.LastHashCheckDate = now;
                file.Attempts = 1;
            }
            else
            {
                file.UploadNeeded = true;
                file.Attempts++;
            }

            await _dataContext
                .SaveChanges(cancellationToken)
                .ConfigureAwait(Await.Default);

            return uploadResult;
        }
    }
}
