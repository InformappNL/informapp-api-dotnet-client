using Informapp.InformSystem.WebApi.Client;
using Informapp.InformSystem.WebApi.Client.RestSharp;
using Informapp.InformSystem.WebApi.Models;
using Informapp.InformSystem.IntegrationTool.Core;

namespace Informapp.InformSystem.IntegrationTool.App
{
    /// <summary>
    /// Dummy class to reference this assembly
    /// </summary>
    public static class IntegrationToolAppProject
    {
        /// <summary>
        /// Dummy method, calling this will load its assembly
        /// </summary>
        public static void Load()
        {
            WebApiClientProject.Load();
            WebApiModelsProject.Load();
            WebApiClientRestSharpProject.Load();

            IntegrationToolCoreProject.Load();
        }
    }
}
