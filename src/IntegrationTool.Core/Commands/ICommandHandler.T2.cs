using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands
{
    /// <summary>
    /// Generic command handler abstraction
    /// </summary>
    public interface ICommandHandler<TCommand, TResult>
        where TCommand : class, ICommand<TResult>
        where TResult : class
    {
        /// <summary>
        /// Handle the command and return the result
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The result</returns>
        Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
