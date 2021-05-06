using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Uploaders
{
    /// <summary>
    /// Generic interface for Uploader{TCommand}
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface IUploader<TCommand>
        where TCommand : class, IUploadCommand
    {
        /// <summary>
        /// Initiates upload for {TCommand}
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        Task<IUploadResult> Upload(TCommand command, CancellationToken cancellationToken);
    }
}
