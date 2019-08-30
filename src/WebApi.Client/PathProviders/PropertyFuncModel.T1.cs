using Informapp.InformSystem.WebApi.Client.Arguments;
using System;

namespace Informapp.InformSystem.WebApi.Client.PathProviders
{
    internal class PropertyFuncModel<T>
    {
        public PropertyFuncModel(
            string name,
            bool isReferenceType,
            Func<T, object> func)
        {
            Argument.NotNullOrEmpty(name, nameof(name));
            Argument.NotNull(func, nameof(func));

            Name = name;

            IsReferenceType = isReferenceType;

            Func = func;
        }

        public string Name { get; }

        public bool IsReferenceType { get; }

        public Func<T, object> Func { get; }
    }
}
