using Autofac;
using Informapp.InformSystem.WebApi.Client.Assemblies;
using Informapp.InformSystem.IntegrationTool.Core.Jobs;
using System.Linq;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register jobs in Autofac
    /// </summary>
    public class JobRegistration : IAutofacRegistration
    {
        private readonly IAssemblyProvider _assemblyProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobRegistration"/> class.
        /// </summary>
        public JobRegistration(
            IAssemblyProvider assemblyProvider)
        {
            Argument.NotNull(assemblyProvider, nameof(assemblyProvider));

            _assemblyProvider = assemblyProvider;
        }

        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            var service = typeof(IJob);

            var types = _assemblyProvider.GetLocalAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass == true)
                .Where(x => x.IsPublic == true)
                .Where(x => x.IsAbstract == false)
                .Where(x => x.IsGenericType == false)
                .Where(x => typeof(IJob).IsAssignableFrom(x))
                .ToArray();

            foreach (var type in types)
            {
                _ = builder.RegisterType(type)
                    .As<IJob>()
                    .InstancePerLifetimeScope();
            }
        }
    }
}
