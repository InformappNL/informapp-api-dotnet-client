using ConnectedDevelopment.InformSystem.IntegrationTool.Core;
using ConnectedDevelopment.InformSystem.WebApi.Client;
using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp;
using ConnectedDevelopment.InformSystem.WebApi.Models;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.App
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
