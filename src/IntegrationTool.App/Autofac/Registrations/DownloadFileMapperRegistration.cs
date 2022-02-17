using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.Files;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register download file mapper in Autofac
    /// </summary>
    public class DownloadFileMapperRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterGeneric(typeof(DownloadFileV1Mapper<,>))
                .As(typeof(IDownloadFileMapper<,>))
                .InstancePerLifetimeScope();

            _ = builder.RegisterGeneric(typeof(DownloadFileV2Mapper<,>))
                .As(typeof(IDownloadFileMapper<,>))
                .InstancePerLifetimeScope();
        }
    }
}
