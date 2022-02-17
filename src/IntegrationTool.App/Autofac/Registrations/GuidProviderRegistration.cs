using Autofac;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Providers;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register guid provider in Autofac
    /// </summary>
    public class GuidProviderRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<GuidProvider>()
                .As<IGuidProvider>()
                .InstancePerLifetimeScope();
        }
    }
}
