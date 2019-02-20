using Informapp.InformSystem.WebApi.Models.Http;

namespace Informapp.InformSystem.WebApi.Client.MethodProviders
{
    /// <summary>
    /// Generic interface to retrieve method from a class
    /// </summary>
    /// <typeparam name="T">Type to get method from</typeparam>
    public interface IMethodProvider<T>
        where T : class
    {
        /// <summary>
        /// Get method
        /// </summary>
        /// <returns>The method</returns>
        HttpMethod? GetMethod();
    }
}
