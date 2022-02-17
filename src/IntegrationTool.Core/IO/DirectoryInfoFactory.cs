using System.IO.Abstractions;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IO
{
    /// <summary>
    /// Directory info factory
    /// </summary>
    public class DirectoryInfoFactory : IDirectoryInfoFactory
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryInfoFactory"/> class.
        /// </summary>
        public DirectoryInfoFactory(
            IFileSystem fileSystem)
        {
            Argument.NotNull(fileSystem, nameof(fileSystem));

            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Create a IDirectoryInfo instance from a directory name.
        /// </summary>
        /// <param name="directoryName">The directory name.</param>
        /// <returns>The created IDirectoryInfo instance.</returns>
        public IDirectoryInfo FromDirectoryName(string directoryName)
        {
            return _fileSystem.DirectoryInfo.FromDirectoryName(directoryName);
        }
    }
}
