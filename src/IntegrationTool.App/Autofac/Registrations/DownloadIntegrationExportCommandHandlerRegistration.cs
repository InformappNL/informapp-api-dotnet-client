using Autofac;
using ConnectedDevelopment.InformSystem.IntegrationTool.Core.IntegrationExports;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register download integration export command handler in Autofac
    /// </summary>
    public class DownloadIntegrationExportCommandHandlerRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<DownloadIntegrationExportCommandHandler>()
                .As<IDownloadIntegrationExportCommandHandler>()
                .InstancePerLifetimeScope();

            builder.RegisterDecorator<ValidateDownloadIntegrationExportCommandHandlerDecorator, IDownloadIntegrationExportCommandHandler>();
            builder.RegisterDecorator<ErrorDownloadIntegrationExportCommandHandlerDecorator, IDownloadIntegrationExportCommandHandler>();
            builder.RegisterDecorator<ReportDownloadIntegrationExportCommandHandlerDecorator, IDownloadIntegrationExportCommandHandler>();
            builder.RegisterDecorator<AcceptDownloadIntegrationExportCommandHandlerDecorator, IDownloadIntegrationExportCommandHandler>();
            builder.RegisterDecorator<RejectDownloadIntegrationExportCommandHandlerDecorator, IDownloadIntegrationExportCommandHandler>();
            builder.RegisterDecorator<SanitiseFileNameDownloadIntegrationExportCommandHandlerDecorator, IDownloadIntegrationExportCommandHandler>();
            builder.RegisterDecorator<ConfigurationDownloadIntegrationExportCommandHandlerDecorator, IDownloadIntegrationExportCommandHandler>();
            builder.RegisterDecorator<DebugDownloadIntegrationExportCommandHandlerDecorator, IDownloadIntegrationExportCommandHandler>();
        }
    }
}
