
namespace ConnectedDevelopment.InformSystem.WebApi.Client.QueryStringProviders
{
    /// <summary>
    /// Generic interface to retrieve query string for a class
    /// </summary>
    /// <typeparam name="T">Type to get query string from</typeparam>
    public interface IQueryProvider<T>
    {
        /// <summary>
        /// Get query string for the given instance
        /// </summary>
        /// <param name="instance">Make query string from this object</param>
        /// <returns>The query string</returns>
        string GetQueryString(T instance);
    }
}
