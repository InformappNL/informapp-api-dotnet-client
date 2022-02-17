using ConnectedDevelopment.InformSystem.WebApi.Client.RestSharp;
using ConnectedDevelopment.InformSystem.WebApi.Models;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Sample
{
    /// <summary>
    /// Dummy class to reference this assembly
    /// </summary>
    public sealed class WebApiClientSampleProject
    {
        /// <summary>
        /// Dummy method, calling this will load its assembly
        /// </summary>
        public static void Load()
        {
            WebApiClientProject.Load();
            WebApiModelsProject.Load();
            WebApiClientRestSharpProject.Load();
        }
    }
}
