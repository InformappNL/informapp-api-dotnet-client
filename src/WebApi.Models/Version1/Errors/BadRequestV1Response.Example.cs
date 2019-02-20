using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System.Collections.Generic;
using System.Diagnostics;

namespace Informapp.InformSystem.WebApi.Models.Version1.Errors
{
    public partial class BadRequestV1Response : IExampleMemberProvider
    {
        static BadRequestV1Response()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                var modelState = new Dictionary<string, IEnumerable<string>>
                {
                    { "request.Example", new[] { "The Example field is required." } },
                };

                var example = new BadRequestV1Response
                {
                    ModelState = modelState,
                };

                _container.Add(nameof(example.ModelState), example.ModelState);
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
