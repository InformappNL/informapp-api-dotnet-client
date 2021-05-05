using Autofac;
using Informapp.InformSystem.WebApi.Client.Configuration;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;

namespace Informapp.InformSystem.WebApi.Client.Sample.Autofac.Registrations
{
    /// <summary>
    /// Register dependencies in Autofac
    /// </summary>
    internal class OptionsRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register dependencies in Autofac
        /// </summary>
        /// <param name="builder">The builder</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            var configurationBuilder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            var configurationRoot = configurationBuilder.Build();

            RegisterSection<ApiConfiguration>(builder, configurationRoot, "ApiSettings");
        }

        private static void RegisterSection<TOptions>(ContainerBuilder builder, IConfigurationRoot configurationRoot, string key)
            where TOptions : class, new()
        {
            var configuration = configurationRoot
                .GetSection(key)
                .Get<TOptions>();

            Require.NotNull(configuration, nameof(configuration));

            var options = Options.Create(configuration);

            _ = builder.Register(x => options)
                .SingleInstance();

            builder.RegisterDecorator<ValidateOptionsDecorator<TOptions>, IOptions<TOptions>>();
            builder.RegisterDecorator<EagerValidateOptionsDecorator<TOptions>, IOptions<TOptions>>();
        }
    }
}
