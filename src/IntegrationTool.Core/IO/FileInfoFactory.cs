using System.IO.Abstractions;

namespace Informapp.InformSystem.IntegrationTool.Core.IO
{
    /// <summary>
    /// File info factory
    /// </summary>
    public class FileInfoFactory : IFileInfoFactory
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileInfoFactory"/> class.
        /// </summary>
        public FileInfoFactory(
            IFileSystem fileSystem)
        {
            Argument.NotNull(fileSystem, nameof(fileSystem));

            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Create a IFileInstance from a filename.
        /// </summary>
        /// <param name="fileName">A string specifying the file on which to create the IFileInfo.</param>
        /// <returns>The created IFileInfo instance.</returns>
        public IFileInfo FromFileName(string fileName)
        {
            return _fileSystem.FileInfo.FromFileName(fileName);
        }
    }
}
