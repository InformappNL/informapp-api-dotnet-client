using ConnectedDevelopment.InformSystem.IntegrationTool.App.Resources;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App
{
    internal static class Program
    {
        internal static async Task Main()
        {
            IntegrationToolAppProject.Load();

            bool debug = false;

#if DEBUG
            debug = Debugger.IsAttached;
#endif

            if (debug == true)
            {
                Console.WriteLine(MessageResource.PressEnterToStart);

                _ = Console.ReadLine();
            }

            try
            {
#pragma warning disable IDE0063 // Use simple 'using' statement
                using (var source = new CancellationTokenSource())
                using (var handler = new CancellationEventHandler(source))
#pragma warning restore IDE0063 // Use simple 'using' statement
                {
                    var cancellationToken = source.Token;

                    var application = new ConsoleApplication();

                    await application
                        .Run(cancellationToken)
                        .ConfigureAwait(Await.Default);
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                Console.WriteLine(MessageResource.ExceptionThrown);

                Console.WriteLine(ex);
            }

            if (debug == true)
            {
                Console.WriteLine("");

                Console.WriteLine(MessageResource.PressEnterToExit);

                _ = Console.ReadLine();
            }
        }
    }
}
