using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Jobs
{
    /// <summary>
    /// Swallow exception job handler decorator
    /// </summary>
    /// <typeparam name="T">The type of job</typeparam>
    public class SwallowExceptionJobHandlerDecorator<T> : Decorator<IJobHandler<T>>,
        IJobHandler<T>

        where T : IJob
    {
        private readonly IJobHandler<T> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwallowExceptionJobHandlerDecorator{T}"/> class.
        /// </summary>
        public SwallowExceptionJobHandlerDecorator(
            IJobHandler<T> handler) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));

            _handler = handler;
        }

        /// <summary>
        /// Execute job
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        public async Task Execute(CancellationToken cancellationToken)
        {
            try
            {
                await _handler
                    .Execute(cancellationToken)
                    .ConfigureAwait(Await.Default);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
#pragma warning disable CA1031       
            catch (Exception)
#pragma warning restore CA1031       
            {

            }
        }
    }
}
