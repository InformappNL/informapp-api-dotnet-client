using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IO
{
    /// <summary>
    /// Directory creator interface
    /// </summary>
    public interface IDirectoryCreator
    {
        /// <summary>
        /// Starts the creation of a directory
        /// </summary>
        /// <param name="path">String of the directory path</param>
        void CreateDirectory(string path);

        /// <summary>
        /// Starts the creation of a directory async
        /// </summary>
        /// <param name="path">String of the directory path</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>Completed task</returns>
        Task CreateDirectoryAsync(string path, CancellationToken cancellationToken);
    }
}
