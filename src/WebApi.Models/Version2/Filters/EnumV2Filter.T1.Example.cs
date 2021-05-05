using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System;
using System.Diagnostics;
using System.Linq;

namespace Informapp.InformSystem.WebApi.Models.Version2.Filters
{
    public partial class EnumV2Filter<T> : IExampleMemberProvider
    {
        static EnumV2Filter()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                var value = Enum.GetValues(typeof(T))
                    .OfType<T>()
                    .FirstOrDefault();

                var example = new EnumV2Filter<T>
                {
                    Equal = value,
                };

                _ = _container.Add(nameof(example.Equal), example.Equal);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ExampleValuesContainer _container = new ExampleValuesContainer();

#pragma warning disable CA1033 // Interface methods should be callable by child types
        object IExampleMemberProvider.GetExample(string name)
#pragma warning restore CA1033 // Interface methods should be callable by child types
        {
            return _container.GetExample(name);
        }
    }
}
