using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System;
using System.Diagnostics;

namespace Informapp.InformSystem.WebApi.Models.Version2.Filters
{
    public partial class GuidV2Filter : IExampleMemberProvider
    {
        static GuidV2Filter()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                var values = new[]
                {
                    Guid.Parse("F7F6F950-F0F4-4A43-A90A-3485D2720034"),
                    Guid.Parse("89B0AFDD-C5EC-443D-99A0-E2C2FDD79B5E"),
                };

                var example = new GuidV2Filter
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
