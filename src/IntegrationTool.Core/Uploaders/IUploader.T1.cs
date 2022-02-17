using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Uploaders
{
    /// <summary>
    /// Generic uploader abstraction
    /// </summary>
    /// <typeparam name="TCommand">The type of command</typeparam>
    public interface IUploader<TCommand>
        where TCommand : class, IUploadCommand
    {
        /// <summary>
        /// Handle the command
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The upload result</returns>
        Task<IUploadResult> Upload(TCommand command, CancellationToken cancellationToken);
    }
}
