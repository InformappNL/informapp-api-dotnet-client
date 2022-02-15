using Autofac;
using Informapp.InformSystem.IntegrationTool.Core.IntegrationImports;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register queue integration import command handler in Autofac
    /// </summary>
    public class QueueIntegrationImportCommandHandlerRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<QueueIntegrationImportCommandHandler>()
                .As<IQueueIntegrationImportCommandHandler>()
                .InstancePerLifetimeScope();

            builder.RegisterDecorator<SaveQueueIntegrationImportDecorator, IQueueIntegrationImportCommandHandler>();
            builder.RegisterDecorator<RollbackQueueIntegrationImportDecorator, IQueueIntegrationImportCommandHandler>();
            builder.RegisterDecorator<ValidateQueueIntegrationImportDecorator, IQueueIntegrationImportCommandHandler>();
            builder.RegisterDecorator<DebugQueueIntegrationImportDecorator, IQueueIntegrationImportCommandHandler>();
        }
    }
}
