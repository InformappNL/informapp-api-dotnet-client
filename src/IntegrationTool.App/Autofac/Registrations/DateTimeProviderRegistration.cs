using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.DateTimeProviders;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register datetime provider in Autofac
    /// </summary>
    public class DateTimeProviderRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<DateTimeProvider>()
                .As<IDateTimeProvider>()
                .InstancePerLifetimeScope();
        }
    }
}
