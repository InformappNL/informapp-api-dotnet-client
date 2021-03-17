using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System.Collections.Generic;
using System.Diagnostics;

namespace Informapp.InformSystem.WebApi.Models.Version2.Errors
{
    public partial class BadRequestV2Response : IExampleMemberProvider
    {
        static BadRequestV2Response()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                var modelState = new Dictionary<string, IEnumerable<string>>
                {
                    { "request.Example", new[] { "The Example field is required." } },
                };

                var example = new BadRequestV2Response
                {
                    ModelState = modelState,
                };

                _ = _container.Add(nameof(example.ModelState), example.ModelState);
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
