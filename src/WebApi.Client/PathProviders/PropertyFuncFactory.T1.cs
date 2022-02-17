using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.PathProviders
{
    internal class PropertyFuncFactory<T>
    {
        public Func<T, object> Create(PropertyInfo propertyInfo)
        {
            var methodInfo = propertyInfo.GetGetMethod();

            var parameter = Expression.Parameter(typeof(T), "x");

            var call = Expression.Call(parameter, methodInfo);

            var convert = Expression.Convert(call, typeof(object));

            var lambda = Expression.Lambda<Func<T, object>>(convert, parameter);

            return lambda.Compile();
        }
    }
}
