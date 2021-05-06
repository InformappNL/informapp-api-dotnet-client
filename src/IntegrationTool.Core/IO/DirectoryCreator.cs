using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IO
{
    /// <summary>
    /// Directory creator class
    /// </summary>
    public class DirectoryCreator : IDirectoryCreator
    {
        private readonly IDirectoryInfoFactory _directoryInfoFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryCreator"/> class
        /// </summary>
        public DirectoryCreator(
            IDirectoryInfoFactory directoryInfoFactory)
        {
            Argument.NotNull(directoryInfoFactory, nameof(directoryInfoFactory));

            _directoryInfoFactory = directoryInfoFactory;
        }

        /// <summary>
        /// Starts creation of a new directory at the provided path
        /// </summary>
        /// <param name="path">Path string</param>
        public void CreateDirectory(string path)
        {
            CreateDirectoryInternal(path);
        }

        /// <summary>
        /// Creates a new directory async
        /// </summary>
        /// <param name="path">Path string</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>Completed task</returns>
        public Task CreateDirectoryAsync(string path, CancellationToken cancellationToken)
        {
            CreateDirectoryInternal(path);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Creates the new directory at the provided path
        /// </summary>
        /// <param name="path">Path string</param>
        private void CreateDirectoryInternal(string path)
        {
            var directory = _directoryInfoFactory.FromDirectoryName(path);

            if (directory.Exists == false)
            {
                directory.Create();
            }
        }
    }
}
