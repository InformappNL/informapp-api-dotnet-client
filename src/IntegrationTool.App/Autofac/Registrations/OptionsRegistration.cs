using Autofac;
using Informapp.InformSystem.WebApi.Client.Configuration;
using Informapp.InformSystem.IntegrationTool.Core.Configurations;
using Informapp.InformSystem.IntegrationTool.Core.Requires;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;

namespace Informapp.InformSystem.IntegrationTool.App.Autofac.Registrations
{
    /// <summary>
    /// Register options in Autofac
    /// </summary>
    public class OptionsRegistration : IAutofacRegistration
    {
        /// <summary>
        /// Register services in Autofac
        /// </summary>
        /// <param name="builder">The container builder instance to use</param>
        public void Register(ContainerBuilder builder)
        {
            Argument.NotNull(builder, nameof(builder));

            bool optional = false;

            bool reloadOnChange = false;

            var configurationBuilder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional, reloadOnChange);

#if DEBUG
            configurationBuilder = configurationBuilder
                .AddUserSecrets(typeof(IntegrationToolAppProject).Assembly);
#endif

            var configurationRoot = configurationBuilder.Build();

            RegisterSection<ApiConfiguration>(builder, configurationRoot, "InformSystemApi");
            RegisterSection<DataContextConfiguration>(builder, configurationRoot, "DataContext");
            RegisterSection<DataSourceConfiguration>(builder, configurationRoot, "DataSources");
            RegisterSection<IntegrationConfiguration>(builder, configurationRoot, "Integrations");
            RegisterSection<IntegrationExportConfiguration>(builder, configurationRoot, "IntegrationExports");
            RegisterSection<IntegrationImportConfiguration>(builder, configurationRoot, "IntegrationImports");
            RegisterSection<CleanupFolderConfiguration>(builder, configurationRoot, "CleanupFolders");
        }

        private static void RegisterSection<TOptions>(ContainerBuilder builder, IConfigurationRoot configurationRoot, string key)
            where TOptions : class, new()
        {
            var configuration = configurationRoot
                .GetSection(key)
                .Get<TOptions>();

            Require.NotNull(configuration, nameof(configuration));

            var options = Options.Create(configuration);

            var value = options.Value;

            Require.NotNull(value, nameof(value));

            _ = builder.Register(x => options)
                .SingleInstance();

            builder.RegisterDecorator<ValidateOptionsDecorator<TOptions>, IOptions<TOptions>>();
        }
    }
}
