using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples
{
    /// <summary>
    /// Interface for examples
    /// </summary>
    public interface IExample
    {
        /// <summary>
        /// Execute example
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        Task Execute(CancellationToken cancellationToken);
    }
}
