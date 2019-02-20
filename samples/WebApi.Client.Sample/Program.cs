using Informapp.InformSystem.WebApi.Client.Sample.Autofac;
using System;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample
{
    internal static class Program
    {
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

            try
            {
                using (var container = AutofacContainerFactory.Create())
                {
                    var program = new ApiExampleProgram(container);

                    await program.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception was thrown:");
                Console.WriteLine(ex);
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
