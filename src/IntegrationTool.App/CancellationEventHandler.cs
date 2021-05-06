using Informapp.InformSystem.IntegrationTool.App.Resources;
using System;
using System.Threading;

namespace Informapp.InformSystem.IntegrationTool.App
{
    /// <summary>
    /// Cancellation event handler
    /// </summary>
#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
    public class CancellationEventHandler : IDisposable
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix
    {
        private readonly CancellationTokenSource _source;

        /// <summary>
        /// Initializes a new instance of the <see cref="CancellationEventHandler"/> class.
        /// </summary>
        /// <param name="source">The cancellation token source</param>
        public CancellationEventHandler(
            CancellationTokenSource source)
        {
            Argument.NotNull(source, nameof(source));

            _source = source;

            Console.CancelKeyPress += ConsoleCancelKeyPress;
        }

        private void ConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Argument.NotNull(e, nameof(e));

            if (_source.IsCancellationRequested == false)
            {
                e.Cancel = true;

                Console.WriteLine(MessageResource.CancellationRequest);

                _source.Cancel();
            }
        }



        #region IDisposable

        private bool disposed;

        /// <summary>
        /// Releases the unmanaged resources used and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed == false)
            {
                if (disposing == true)
                {
                    _source.Dispose();

                    /*
                     * Do not unsubscribe, leads to deadlock
                     * 
                     * https://github.com/dotnet/corefx/issues/26043
                     * 
                     */
                    //Console.CancelKeyPress -= ConsoleCancelKeyPress;
                }

                disposed = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
