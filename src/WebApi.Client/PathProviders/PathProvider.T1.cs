using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.AttributeProviders;
using Informapp.InformSystem.WebApi.Models.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Informapp.InformSystem.WebApi.Client.PathProviders
{
    /// <summary>
    /// Retrieve path for a class
    /// </summary>
    /// <typeparam name="T">Type to get path from</typeparam>
    public class PathProvider<T> : IPathProvider<T>
        where T : class
    {
        private static readonly PathAttribute _attribute = AttributeProvider.Create<T, PathAttribute>(true)
            .ThrowIfMultiple()
            .Attribute;

        private static readonly IList<PropertyFuncModel<T>> _properties = GetProperties();

        private static IList<PropertyFuncModel<T>> GetProperties()
        {
            IList<PropertyFuncModel<T>> properties = null;

            if (_attribute != null)
            {
                var factory = new PropertyFuncFactory<T>();

                properties = typeof(T)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(x => x.CanRead)
                    .Where(x => _attribute.Pattern.Contains('{' + x.Name + '}'))
                    .Where(x => x.GetCustomAttributes<PathParameterAttribute>(false).Any() == true)
                    .Select(x => new PropertyFuncModel<T>(
                        x.Name,
                        x.PropertyType.IsClass || x.PropertyType.IsInterface,
                        factory.Create(x)))
                    .ToList();
            }

            return properties;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathProvider{T}"/> class.
        /// </summary>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/> is missing <see cref="PathAttribute"/></exception>
        public PathProvider()
        {
            if (_attribute == null)
            {
                string message = typeof(T).Name + " is missing attribute " + nameof(PathAttribute);

                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Get path for the given instance
        /// </summary>
        /// <param name="instance">Fill path with values from this object</param>
        /// <returns>The path</returns>
        /// <exception cref="ArgumentNullException"><paramref name="instance"/> is null</exception>
        public Uri GetPath(T instance)
        {
            Argument.NotNull(instance, nameof(instance));

            string path;

            if (_properties.Count > 0)
            {
                var builder = new StringBuilder(_attribute.Pattern);

                foreach (var property in _properties)
                {
                    var value = property.Func.Invoke(instance);

                    string pathValue = string.Empty;

                    if (property.IsReferenceType == false || value != null)
                    {
                        pathValue = string.Format(CultureInfo.InvariantCulture, "{0}", value);
                    }

                    builder.Replace('{' + property.Name + '}', pathValue);
                }
                
                path = builder.ToString();
            }
            else
            {
                path = _attribute.Pattern;
            }
            
            return new Uri(path, UriKind.Relative);
        }
    }
}
