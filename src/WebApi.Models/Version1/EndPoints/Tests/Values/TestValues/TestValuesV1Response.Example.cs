using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System.Collections.Generic;
using System.Diagnostics;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestValues
{
    public partial class TestValuesV1Response : IExampleMemberProvider
    {
        static TestValuesV1Response()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                var dictionary = new Dictionary<int, int>
                {
                    { 1, 10 },
                    { 2, 20 },
                    { 3, 30 },
                };

                var example = new TestValuesV1Request
                {
                    Dictionary = dictionary,
                };

                _container.Add(nameof(example.Dictionary), example.Dictionary);
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
