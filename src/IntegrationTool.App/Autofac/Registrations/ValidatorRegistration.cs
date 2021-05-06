using Autofac;
using Informapp.InformSystem.WebApi.Client.Assemblies;
using Informapp.InformSystem.WebApi.Client.Validators;
using Informapp.InformSystem.IntegrationTool.Core.Validators;
using System.Linq;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register validators in Autofac
    /// </summary>
    public class ValidatorRegistration : IAutofacRegistration
    {
        private readonly IAssemblyProvider _assemblyProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorRegistration"/> class.
        /// </summary>
        public ValidatorRegistration(
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

            var serviceType = typeof(IValidator<>);

            _ = builder.RegisterGeneric(typeof(Validator<>))
                .As(serviceType)
                .InstancePerLifetimeScope();

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

            _ = builder.RegisterGenericComposite(typeof(CompositeValidator<>), serviceType)
                .InstancePerLifetimeScope();
        }
    }
}
