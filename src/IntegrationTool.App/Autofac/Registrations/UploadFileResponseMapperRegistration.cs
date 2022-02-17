using Autofac;
using ConnectedDevelopment.InformSystem.WebApi.Client.Files;


namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register upload file response mapper in Autofac
    /// </summary>
    public class UploadFileResponseMapperRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            _ = builder.RegisterGeneric(typeof(UploadFileV1ResponseMapper<,>))
                .As(typeof(IUploadFileResponseMapper<,>))
                .InstancePerLifetimeScope();

            _ = builder.RegisterGeneric(typeof(UploadFileV2ResponseMapper<,>))
                .As(typeof(IUploadFileResponseMapper<,>))
                .InstancePerLifetimeScope();
        }
    }
}
