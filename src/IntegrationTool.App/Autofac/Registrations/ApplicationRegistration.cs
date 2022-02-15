using Autofac;
using Informapp.InformSystem.IntegrationTool.Core.Applications;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register application in Autofac
    /// </summary>
    public class ApplicationRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterType<Application>()
                .As<IApplication>()
                .InstancePerLifetimeScope();

            builder.RegisterDecorator<DataContextApplicationDecorator, IApplication>();

            //builder.RegisterDecorator<ApiAvailableApplicationDecorator, IApplication>();

            builder.RegisterDecorator<CleanDownloadFolderApplicationDecorator, IApplication>();

            builder.RegisterDecorator<HeartbeatApplicationDecorator, IApplication>();

            //builder.RegisterDecorator<SingleInstanceApplicationDecorator, IApplication>();

            builder.RegisterDecorator<CancelledApplicationDecorator, IApplication>();

            builder.RegisterDecorator<LogApplicationDecorator, IApplication>();

            builder.RegisterDecorator<LogExceptionApplicationDecorator, IApplication>();

            builder.RegisterDecorator<SwallowExceptionApplicationDecorator, IApplication>();

            builder.RegisterDecorator<Log4NetApplicationDecorator, IApplication>();
        }
    }
}
