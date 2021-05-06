using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Queries
{
    /// <summary>
    /// Generic query handler interface
    /// </summary>
    /// <typeparam name="TQuery">The query</typeparam>
    /// <typeparam name="TResult">The result</typeparam>
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : class, IQuery<TResult>
        where TResult : class
    {
        /// <summary>
        /// Handle the query
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The result</returns>
        Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
