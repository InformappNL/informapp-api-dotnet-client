using System.Collections.Generic;
using System.Reflection;

namespace Informapp.InformSystem.WebApi.Client.Assemblies
{
    /// <summary>
    /// Assembly provider interface
    /// </summary>
    public interface IAssemblyProvider
    {
        /// <summary>
        /// Retrieve a list of local assemblies
        /// </summary>
        /// <returns>The list of local assemblies</returns>
        IReadOnlyList<Assembly> GetLocalAssemblies();
    }
}
