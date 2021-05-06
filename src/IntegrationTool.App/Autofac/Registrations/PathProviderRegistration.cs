using Autofac;
using Informapp.InformSystem.WebApi.Client.PathProviders;


namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register path provider in Autofac
    /// </summary>
    public class PathProviderRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterGeneric(typeof(PathProvider<>))
                .As(typeof(IPathProvider<>))
                .InstancePerLifetimeScope();
        }
    }
}
