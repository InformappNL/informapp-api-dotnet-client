﻿using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using System;
using System.Threading;

namespace Informapp.InformSystem.WebApi.Client.Sample.Consoles
{
    internal class ConsoleCancellationEventHandler : IDisposable
    {
        private readonly CancellationTokenSource _source;

        public ConsoleCancellationEventHandler(
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

                Console.WriteLine("Cancellation requested.");

                _source.Cancel();
            }
        }



        #region IDisposable

        private bool disposed = false;

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

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
