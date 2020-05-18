using Informapp.InformSystem.WebApi.Client.Sample.Autofac;
using Informapp.InformSystem.WebApi.Client.Sample.Consoles;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample
{
    internal static class Program
    {
        private static readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private static bool isCancellationRequested = false;

        static Program()
        {
            ConsoleHelper.SetInputBufferSize(1024);
        }

        private static void Main()
        {
            MainAsync()
                .GetAwaiter()
                .GetResult();
        }

        private static async Task MainAsync()
        {
            Console.WriteLine("Press enter to run examples");
            _ = Console.ReadLine();

            Console.CancelKeyPress += ConsoleCancelKeyPress;

            var cancellationToken = _cancellationTokenSource.Token;

            try
            {
#pragma warning disable CA1508 // Avoid dead conditional code
                using (var container = AutofacContainerFactory.Create())
#pragma warning restore CA1508 // Avoid dead conditional code
                {
                    var program = new ApiExampleProgram(container);

                    await program.Start(cancellationToken)
                        .ConfigureAwait(Await.Default);
                }
            }
            catch (OperationCanceledException) when (isCancellationRequested == true)
            {
                Console.WriteLine("Cancelled.");
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                Console.WriteLine("An exception was thrown:");
                Console.WriteLine(ex);
            }
            finally
            {
                _cancellationTokenSource.Dispose();
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            _ = Console.ReadLine();
        }

        private static void ConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;

            if (isCancellationRequested == false)
            {
                Console.WriteLine("Cancellation requested");

                isCancellationRequested = true;

                _cancellationTokenSource.Cancel();
            }
        }
    }
}
