using Autofac;
using Informapp.InformSystem.WebApi.Client.DictionaryBuilders;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register query dictionary builder in Autofac
    /// </summary>
    public class QueryDictionaryBuilderRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterGeneric(typeof(QueryDictionaryBuilder<>))
                .As(typeof(IQueryDictionaryBuilder<>))
                .InstancePerLifetimeScope();
        }
    }
}
