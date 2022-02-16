using Autofac;
using Informapp.InformSystem.IntegrationTool.App.AppStart;
using Informapp.InformSystem.WebApi.Client.Assemblies;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    public class AssemblyProviderRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<DefaultAssemblyProvider>()
                .As<IAssemblyProvider>()
                .InstancePerLifetimeScope();
        }
    }
}
