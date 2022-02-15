using Autofac;
using Informapp.InformSystem.IntegrationTool.Core.Loggers;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register application logger in Autofac
    /// </summary>
    public class ApplicationLoggerRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.Register(x => new Logger("App"))
                .As<IApplicationLogger>()
                .InstancePerLifetimeScope();

            builder.RegisterDecorator<LogExceptionApplicationLoggerDecorator, IApplicationLogger>();
        }
    }
}
