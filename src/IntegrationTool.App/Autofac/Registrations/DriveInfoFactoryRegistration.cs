using Autofac;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.IO;
using System.IO.Abstractions;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register drive info factory in Autofac
    /// </summary>
    public class DriveInfoFactoryRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<DriveInfoFactory>()
                .As<IDriveInfoFactory>()
                .InstancePerLifetimeScope();
        }
    }
}
