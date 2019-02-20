using System;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.AttributeProviders
{
    /// <summary>
    /// Generic provider interface to retrieve class level attributes
    /// </summary>
    /// <typeparam name="TType">The type</typeparam>
    /// <typeparam name="TAttribute">The attribute type</typeparam>
    internal interface IAttributeProvider<TType, TAttribute>
        where TAttribute : Attribute
    {
        /// <summary>
        /// The number of attributes
        /// </summary>
        int Count { get; }

        /// <summary>
        /// The first attribute
        /// </summary>
        TAttribute Attribute { get; }

        /// <summary>
        /// All attributes
        /// </summary>
        /// <returns></returns>
        IList<TAttribute> GetAttributes();
    }
}
