using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Commands
{
    /// <summary>
    /// Generic ICommandHandler interface
    /// </summary>
    public interface ICommandHandler<TCommand, TResult>
        where TCommand : class, ICommand<TResult>
        where TResult : class
    {
        /// <summary>
        /// Generic handle task
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The resonse</returns>
        Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
