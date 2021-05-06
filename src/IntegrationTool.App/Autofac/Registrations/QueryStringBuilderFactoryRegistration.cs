using Autofac;
using Informapp.InformSystem.WebApi.Client.QueryStrings;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register query string builder factory in Autofac
    /// </summary>
    public class QueryStringBuilderFactoryRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<QueryStringBuilderFactory>()
                .As<IQueryStringBuilderFactory>()
                .InstancePerLifetimeScope();
        }
    }
}
