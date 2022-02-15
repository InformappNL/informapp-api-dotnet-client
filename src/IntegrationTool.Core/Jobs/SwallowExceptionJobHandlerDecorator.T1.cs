using Informapp.InformSystem.WebApi.Client.Decorators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Jobs
{
    public class SwallowExceptionJobHandlerDecorator<T> : Decorator<IJobHandler<T>>,
        IJobHandler<T>

        where T : IJob
    {
        private readonly IJobHandler<T> _handler;

        public SwallowExceptionJobHandlerDecorator(
            IJobHandler<T> handler) : base(handler)
        {
            Argument.NotNull(handler, nameof(handler));

            _handler = handler;
        }

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
