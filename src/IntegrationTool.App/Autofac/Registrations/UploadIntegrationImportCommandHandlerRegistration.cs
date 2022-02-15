using Autofac;
using Informapp.InformSystem.IntegrationTool.Core.IntegrationImports;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register upload integration import command handler in Autofac
    /// </summary>
    public class UploadIntegrationImportCommandHandlerRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<UploadIntegrationImportCommandHandler>()
                .As<IUploadIntegrationImportCommandHandler>()
                .InstancePerLifetimeScope();

            builder.RegisterDecorator<ValidateUploadIntegrationImportDecorator, IUploadIntegrationImportCommandHandler>();
            builder.RegisterDecorator<ErrorUploadIntegrationImportDecorator, IUploadIntegrationImportCommandHandler>();
            builder.RegisterDecorator<ReportUploadIntegrationImportDecorator, IUploadIntegrationImportCommandHandler>();
            builder.RegisterDecorator<StartUploadIntegrationImportDecorator, IUploadIntegrationImportCommandHandler>();
            builder.RegisterDecorator<MoveFileUploadIntegrationImportDecorator, IUploadIntegrationImportCommandHandler>();
        }
    }
}
