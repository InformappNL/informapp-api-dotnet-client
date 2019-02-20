using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System;
using System.Diagnostics;
using System.Linq;

namespace Informapp.InformSystem.WebApi.Models.Version1.Filters
{
    public partial class EnumV1Filter<T> : IExampleMemberProvider
    {
        static EnumV1Filter()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                var values = Enum.GetValues(typeof(T))
                    .OfType<T>()
                    .Take(2)
                    .ToList();

                var example = new EnumV1Filter<T>
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
