using Informapp.InformSystem.WebApi.Client.Sample.Autofac;
using Informapp.InformSystem.WebApi.Client.Sample.Consoles;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample
{
    internal static class Program
    {
        static Program()
        {
            ConsoleHelper.SetInputBufferSize(1024);
        }

        private static async Task Main()
        {
            CancellationToken cancellationToken;

            try
            {
#pragma warning disable CA1508 // Avoid dead conditional code
                using (var source = new CancellationTokenSource())
                using (var handler = new ConsoleCancellationEventHandler(source))
                using (var container = AutofacContainerFactory.Create())
#pragma warning restore CA1508 // Avoid dead conditional code
                {
                    Console.WriteLine("Press enter to run examples");
                    _ = Console.ReadLine();

                    cancellationToken = source.Token;

                    var program = new ApiExampleProgram(container);

                    await program
                        .Start(cancellationToken)
                        .ConfigureAwait(Await.Default);
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested == true)
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

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            _ = Console.ReadLine();
        }
    }
}
