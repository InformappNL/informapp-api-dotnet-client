using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.IO.Abstractions;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IO
{
    /// <summary>
    /// File stream factory
    /// </summary>
    public class FileStreamFactory : IFileStreamFactory
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStreamFactory"/> class
        /// </summary>
        public FileStreamFactory(
            IFileSystem fileSystem)
        {
            Argument.NotNull(fileSystem, nameof(fileSystem));

            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Create stream
        /// </summary>
        public Stream Create(string path, FileMode mode)
        {
            return _fileSystem.FileStream.Create(path, mode);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        public Stream Create(string path, FileMode mode, FileAccess access)
        {
            return _fileSystem.FileStream.Create(path, mode, access);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        public Stream Create(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return _fileSystem.FileStream.Create(path, mode, access, share);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        public Stream Create(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)
        {
            return _fileSystem.FileStream.Create(path, mode, access, share, bufferSize);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        public Stream Create(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options)
        {
            return _fileSystem.FileStream.Create(path, mode, access, share, bufferSize, options);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        public Stream Create(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync)
        {
            return _fileSystem.FileStream.Create(path, mode, access, share, bufferSize, useAsync);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        public Stream Create(SafeFileHandle handle, FileAccess access)
        {
            return _fileSystem.FileStream.Create(handle, access);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        public Stream Create(SafeFileHandle handle, FileAccess access, int bufferSize)
        {
            return _fileSystem.FileStream.Create(handle, access, bufferSize);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        public Stream Create(SafeFileHandle handle, FileAccess access, int bufferSize, bool isAsync)
        {
            return _fileSystem.FileStream.Create(handle, access, bufferSize, isAsync);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        [Obsolete("This method has been deprecated. Please use new Create(SafeFileHandle handle, FileAccess access) instead. http://go.microsoft.com/fwlink/?linkid=14202")]
        public Stream Create(IntPtr handle, FileAccess access)
        {
            return _fileSystem.FileStream.Create(handle, access);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        [Obsolete("This method has been deprecated. Please use new Create(SafeFileHandle handle, FileAccess access) instead, and optionally make a new SafeFileHandle with ownsHandle=false if needed. http://go.microsoft.com/fwlink/?linkid=14202")]
        public Stream Create(IntPtr handle, FileAccess access, bool ownsHandle)
        {
            return _fileSystem.FileStream.Create(handle, access, ownsHandle);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        [Obsolete("This method has been deprecated. Please use new Create(SafeFileHandle handle, FileAccess access, int bufferSize) instead, and optionally make a new SafeFileHandle with ownsHandle=false if needed. http://go.microsoft.com/fwlink/?linkid=14202")]
        public Stream Create(IntPtr handle, FileAccess access, bool ownsHandle, int bufferSize)
        {
            return _fileSystem.FileStream.Create(handle, access, ownsHandle, bufferSize);
        }

        /// <summary>
        /// Create stream
        /// </summary>
        [Obsolete("This method has been deprecated. Please use new Create(SafeFileHandle handle, FileAccess access, int bufferSize, bool isAsync) instead, and optionally make a new SafeFileHandle with ownsHandle=false if needed. http://go.microsoft.com/fwlink/?linkid=14202")]
        public Stream Create(IntPtr handle, FileAccess access, bool ownsHandle, int bufferSize, bool isAsync)
        {
            return _fileSystem.FileStream.Create(handle, access, ownsHandle, bufferSize, isAsync);
        }
    }
}
