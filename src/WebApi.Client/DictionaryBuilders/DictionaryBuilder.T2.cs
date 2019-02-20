using Informapp.InformSystem.WebApi.Client.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Informapp.InformSystem.WebApi.Client.DictionaryBuilders
{
    /// <summary>
    /// Build a dictionary from an object
    /// </summary>
    /// <typeparam name="TModel">The model</typeparam>
    /// <typeparam name="TAttribute">Only consider properties marked with this attribute</typeparam>
    public class DictionaryBuilder<TModel, TAttribute> : IDictionaryBuilder<TModel, TAttribute>
        where TModel : class
        where TAttribute : Attribute
    {
        private static readonly IEnumerable<Property> _properties;

        static DictionaryBuilder()
        {
            var properties = typeof(TModel).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.CanRead)
                .Where(x => x.GetCustomAttribute<TAttribute>(false) != null)
                .Select(x => new Property
                {
                    Name = x.Name,
                    Func = GetFunc(x)
                })
                .ToList();

            _properties = properties;
        }

        private class Property
        {
            public string Name { get; set; }

            public Func<TModel, object> Func { get; set; }
        }

        private static Func<TModel, object> GetFunc(PropertyInfo propertyInfo)
        {
            var methodInfo = propertyInfo.GetGetMethod();

            var parameter = Expression.Parameter(typeof(TModel), "x");
            var call = Expression.Call(parameter, methodInfo);
            var convert = Expression.Convert(call, typeof(object));

            var lambda = Expression.Lambda<Func<TModel, object>>(convert, parameter);

            return lambda.Compile();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryBuilder{TModel, TAttribute}"/> class.
        /// </summary>
        public DictionaryBuilder()
        {

        }

        /// <summary>
        /// Get dictionary containing property names and their values
        /// </summary>
        /// <param name="model">The model to build a dictionary</param>
        /// <returns>Dictionary of properties</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/></exception>
        public IDictionary<string, object> GetDictionary(TModel model)
        {
            Argument.NotNull(model, nameof(model));

            var dictionary = new Dictionary<string, object>(_properties.Count(), StringComparer.OrdinalIgnoreCase);

            foreach (var property in _properties)
            {
                var value = property.Func.Invoke(model);

                if (value != null)
                {
                    dictionary.Add(property.Name, value);
                }
            }

            return dictionary;
        }
    }
}
