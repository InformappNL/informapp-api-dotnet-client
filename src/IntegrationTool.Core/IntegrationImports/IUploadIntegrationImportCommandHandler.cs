using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Interface for download integration export command handler
    /// </summary>
    public interface IUploadIntegrationImportCommandHandler
    {
        /// <summary>
        /// Handle download integration export command
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        Task<UploadIntegrationImportCommandResult> Handle(
            UploadIntegrationImportCommand command,
            CancellationToken cancellationToken);
    }
}
