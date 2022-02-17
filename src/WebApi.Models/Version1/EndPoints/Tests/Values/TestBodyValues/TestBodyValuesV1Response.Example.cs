using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestBodyValues
{
    public partial class TestBodyValuesV1Response : IExampleMemberProvider
    {
        static TestBodyValuesV1Response()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                var dictionary = new Dictionary<int, int>
                {
                    { 1, 10 },
                    { 2, 20 },
                    { 3, 30 },
                };

                var example = new TestBodyValuesV1Request
                {
                    Dictionary = dictionary,
                };

                _ = _container.Add(nameof(example.Dictionary), example.Dictionary);
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
