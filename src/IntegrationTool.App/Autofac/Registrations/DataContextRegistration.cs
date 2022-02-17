using Autofac;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.DataContexts;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register data context in Autofac
    /// </summary>
    public class DataContextRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<DataContext>()
                .As<IDataContext>()
                .InstancePerLifetimeScope();
        }
    }
}
