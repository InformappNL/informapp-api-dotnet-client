using Autofac;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.IO;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register directory creator in Autofac
    /// </summary>
    public class DirectoryCreatorRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            _ = builder.RegisterType<DirectoryCreator>()
                .As<IDirectoryCreator>()
                .InstancePerLifetimeScope();
        }
    }
}
