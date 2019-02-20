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
                var values = Enum.GetValues(typeof(T))
                    .OfType<T>()
                    .Take(2)
                    .ToList();

                var example = new EnumV2Filter<T>
                {
                    Values = values,
                };

                _container.Add(nameof(example.Values), example.Values);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ExampleValuesContainer _container = new ExampleValuesContainer();

        object IExampleMemberProvider.GetExample(string name)
        {
            return _container.GetExample(name);
        }
    }
}
