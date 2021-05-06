using Autofac;
using Informapp.InformSystem.WebApi.Client.MethodProviders;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register method provider in Autofac
    /// </summary>
    public class MethodProviderRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterGeneric(typeof(MethodProvider<>))
                .As(typeof(IMethodProvider<>))
                .InstancePerLifetimeScope();
        }
    }
}
