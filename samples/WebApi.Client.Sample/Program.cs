using Informapp.InformSystem.WebApi.Client.Sample.Autofac;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample
{
    internal static class Program
    {
        private const int BufferSize = 1024;

        private static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private static bool isCancellationRequested = false;

        static Program()
        {
            SetBufferSize(BufferSize);
        }

        private static void SetBufferSize(int bufferSize)
        {
            var stream = Console.OpenStandardInput(bufferSize);

            var reader = new StreamReader(stream, Console.InputEncoding, false, bufferSize);

            Console.SetIn(reader);
        }

        private static void Main(string[] args)
        {
            MainAsync(args)
                .GetAwaiter()
                .GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Press enter to run examples");
            Console.ReadLine();

            Console.CancelKeyPress += ConsoleCancelKeyPress;

            var cancellationToken = _cancellationTokenSource.Token;

            try
            {
                using (var container = AutofacContainerFactory.Create())
                {
                    var program = new ApiExampleProgram(container);
                    
                    await program.Start(cancellationToken);
                }
            }
            catch (TaskCanceledException ex) when (isCancellationRequested == true)
            {
                Console.WriteLine("Cancelled.");
            }
            catch (Exception ex)
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
            Console.ReadLine();
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
