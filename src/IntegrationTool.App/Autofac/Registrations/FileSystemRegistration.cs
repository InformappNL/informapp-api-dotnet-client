using Autofac;
using System.IO.Abstractions;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register directory info factory in Autofac
    /// </summary>
    public class FileSystemRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<FileSystem>()
                .As<IFileSystem>()
                .InstancePerLifetimeScope();
        }
    }
}
