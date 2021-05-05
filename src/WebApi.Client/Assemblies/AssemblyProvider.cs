using Informapp.InformSystem.WebApi.Client.Arguments;
using System.Collections.Generic;
using System.Reflection;

namespace Informapp.InformSystem.WebApi.Client.Assemblies
{
    /// <summary>
    /// Assembly provider class
    /// </summary>
    public class AssemblyProvider : IAssemblyProvider
    {
        private readonly IReadOnlyList<Assembly> _assemblies;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyProvider"/> class.
        /// </summary>
        public AssemblyProvider(
            IReadOnlyList<Assembly> assemblies)
        {
            Argument.NotNullOrEmpty(assemblies, nameof(assemblies));

            _assemblies = assemblies;
        }

        /// <summary>
        /// Retrieve a list of local assemblies
        /// </summary>
        /// <returns>The list of local assemblies</returns>
        public IReadOnlyList<Assembly> GetLocalAssemblies()
        {
            return _assemblies;
        }
    }
}
