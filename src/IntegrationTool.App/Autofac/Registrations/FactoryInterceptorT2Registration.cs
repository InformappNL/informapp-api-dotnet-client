using Autofac;
using Informapp.InformSystem.IntegrationTool.Core.Factories;
using Informapp.InformSystem.WebApi.Client.Assemblies;
using System.Linq;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register factory interceptors in Autofac
    /// </summary>
    public class FactoryInterceptorT2Registration : IAutofacRegistration
    {
        private readonly IAssemblyProvider _assemblyProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryInterceptorT2Registration"/> class.
        /// </summary>
        public FactoryInterceptorT2Registration(
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

            var serviceType = typeof(IFactoryInterceptor<,>);

            var types = _assemblyProvider.GetLocalAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass == true)
                .Where(x => x.IsGenericType == false)
                .SelectMany(x => x.GetInterfaces(), (i, s) => (Implementor: i, Service: s))
                .Where(x => x.Service.IsGenericType == true)
                .Where(x => x.Service.ContainsGenericParameters == false)
                .Where(x => x.Service.GetGenericTypeDefinition() == serviceType)
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
