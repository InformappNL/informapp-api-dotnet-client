using System.IO;
using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries.CreateStreamFromPath
{
    /// <summary>
    /// Query handler for making a stream from a file
    /// </summary>
    public class CreateStreamFromPathQueryHandler : IQueryHandler<CreateStreamFromPathQuery, CreateStreamFromPathQueryResult>
    {
        private const int BufferSize = 1024 * 16;

        private readonly IPath _path;

        private readonly IFileInfoFactory _fileInfoFactory;

        private readonly IFileStreamFactory _fileStreamFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStreamFromPathQueryHandler"/> class
        /// </summary>
        /// <param name="path">Injected file path provider</param>
        /// <param name="fileInfoFactory">Injected file info factory</param>
        /// /// <param name="fileStreamFactory">Injected file stream factory</param>
        public CreateStreamFromPathQueryHandler(
            IPath path,
            IFileInfoFactory fileInfoFactory,
            IFileStreamFactory fileStreamFactory)
        {
            _path = path;

            _fileInfoFactory = fileInfoFactory;

            _fileStreamFactory = fileStreamFactory;
        }

        /// <summary>
        /// Handles creating a stream from the provided file
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<CreateStreamFromPathQueryResult> Handle(
            CreateStreamFromPathQuery query,
            CancellationToken cancellationToken)
        {
            Argument.NotNull(query, nameof(query));

            var queryResult = new CreateStreamFromPathQueryResult();

            var file = _fileStreamFactory.Create(query.Path, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, useAsync: true);

            queryResult.File = file;
            queryResult.FileName = _path.GetFileName(query.Path);
            queryResult.Path = query.Path;
            queryResult.Size = file.Length;

            var info = _fileInfoFactory.FromFileName(query.Path);

            queryResult.CreationTimeUtc = info.CreationTimeUtc;
            queryResult.LastWriteTimeUtc = info.LastWriteTimeUtc;

            return Task.FromResult(queryResult);
        }
    }
}
