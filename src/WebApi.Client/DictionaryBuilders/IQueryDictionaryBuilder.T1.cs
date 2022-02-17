using ConnectedDevelopment.InformSystem.WebApi.Models.Http;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.DictionaryBuilders
{
    /// <summary>
    /// Generic interface to build a dictionary of query string values from an object
    /// </summary>
    /// <typeparam name="T">The model</typeparam>
    public interface IQueryDictionaryBuilder<T> : IDictionaryBuilder<T, QueryParameterAttribute>
    {

    }
}
