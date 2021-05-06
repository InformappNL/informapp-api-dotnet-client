using Autofac;
using Informapp.InformSystem.WebApi.Client.QueryStringProviders;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register query provider in Autofac
    /// </summary>
    public class QueryProviderRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterGeneric(typeof(QueryProvider<>))
                .As(typeof(IQueryProvider<>))
                .InstancePerLifetimeScope();
        }
    }
}
