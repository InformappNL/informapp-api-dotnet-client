using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.Assemblies;
using ConnectedDevelopment.InformSystem.WebApi.Client.Converters;
using System.Linq;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register converters in Autofac
    /// </summary>
    public class ConverterRegistration : IAutofacRegistration
    {
        private readonly IAssemblyProvider _assemblyProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterRegistration"/> class.
        /// </summary>
        public ConverterRegistration(
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

            var types = _assemblyProvider.GetLocalAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass == true)
                .Where(x => x.IsGenericType == false)
                .SelectMany(x => x.GetInterfaces(), (i, s) => (Implementor: i, Service: s))
                .Where(x => x.Service.IsGenericType == true)
                .Where(x => x.Service.ContainsGenericParameters == false)
                .Where(x => x.Service.GetGenericTypeDefinition() == typeof(IConverter<,>))
                .ToList();

            foreach (var (implementor, service) in types)
            {
                _ = builder.RegisterType(implementor)
                    .As(service)
                    .InstancePerLifetimeScope();
            }
        }
    }
}
