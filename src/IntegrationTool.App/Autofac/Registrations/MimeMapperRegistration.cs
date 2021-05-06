using Autofac;
using Informapp.InformSystem.WebApi.Client.MimeMappers;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register mime mapper in Autofac
    /// </summary>
    public class MimeMapperRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<MimeMapper>()
                .As<IMimeMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
