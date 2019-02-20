using System;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.DictionaryBuilders
{
    /// <summary>
    /// Generic interface to build a dictionary from an object
    /// </summary>
    /// <typeparam name="TModel">The model</typeparam>
    /// <typeparam name="TAttribute">Only consider properties marked with this attribute</typeparam>
    public interface IDictionaryBuilder<TModel, TAttribute>
        where TAttribute : Attribute
    {
        /// <summary>
        /// Get dictionary containing property names and their values
        /// </summary>
        /// <param name="model">The model to build a dictionary</param>
        /// <returns>Dictionary of properties</returns>
        IDictionary<string, object> GetDictionary(TModel model);
    }
}
