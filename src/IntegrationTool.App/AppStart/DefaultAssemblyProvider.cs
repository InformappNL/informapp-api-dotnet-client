using ConnectedDevelopment.InformSystem.WebApi.Client.Assemblies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App.AppStart
{
    /// <summary>
    /// Default assembly provider implementation
    /// </summary>
    public class DefaultAssemblyProvider : IAssemblyProvider
    {
        private readonly IAssemblyProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultAssemblyProvider"/> class.
        /// </summary>
        public DefaultAssemblyProvider()
        {
            var localAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName.StartsWith("xunit", StringComparison.OrdinalIgnoreCase) == false)
                .Where(x => x.GetTypes()
                    .Where(t => string.IsNullOrEmpty(t.Namespace) == false)
                    .Where(t => t.Namespace.StartsWith(nameof(ConnectedDevelopment), StringComparison.OrdinalIgnoreCase))
                    .Any() == true)
                .ToList();

            var provider = new AssemblyProvider(localAssemblies);

            _provider = provider;
        }

        /// <summary>
        /// Retrieve a list of local assemblies
        /// </summary>
        /// <returns>The list of local assemblies</returns>
        public IReadOnlyList<Assembly> GetLocalAssemblies()
        {
            return _provider.GetLocalAssemblies();
        }
    }
}
