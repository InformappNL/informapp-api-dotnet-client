using System.IO.Abstractions;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IO
{
    /// <summary>
    /// Drive info factory
    /// </summary>
    public class DriveInfoFactory : IDriveInfoFactory
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriveInfoFactory"/> class.
        /// </summary>
        public DriveInfoFactory(
            IFileSystem fileSystem)
        {
            Argument.NotNull(fileSystem, nameof(fileSystem));

            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Create a IDriveInfo instance from a drive name.
        /// </summary>
        /// <param name="driveName">The drive name.</param>
        /// <returns>The created IDriveInfo instance.</returns>
        public IDriveInfo FromDriveName(string driveName)
        {
            return _fileSystem.DriveInfo.FromDriveName(driveName);
        }

        /// <summary>
        /// Retrieve a list of drives.
        /// </summary>
        /// <returns>The list of drives.</returns>
        public IDriveInfo[] GetDrives()
        {
            return _fileSystem.DriveInfo.GetDrives();
        }
    }
}
