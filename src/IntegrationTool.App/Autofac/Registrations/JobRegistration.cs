using Autofac;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.Jobs;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register jobs in Autofac
    /// </summary>
    public class JobRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            RegisterJob<UploadDataSourceFileJob>(builder);
            RegisterJob<DownloadIntegrationExportJob>(builder);
            RegisterJob<QueueIntegrationImportJob>(builder);
            RegisterJob<UploadIntegrationImportJob>(builder);
            RegisterJob<CleanFolderJob>(builder);
        }

        private static void RegisterJob<T>(ContainerBuilder builder)
            where T : IJob
        {
            _ = builder.RegisterType<T>()
                .As<IJob>()
                .InstancePerLifetimeScope();
        }
    }
}
