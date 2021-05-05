﻿using Informapp.InformSystem.WebApi.Models.ExampleValues;
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

                _ = _container.Add(nameof(example.ModelState), example.ModelState);
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
