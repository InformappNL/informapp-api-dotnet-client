﻿using Informapp.InformSystem.WebApi.Models.ExampleValues;
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
                var value = Enum.GetValues(typeof(T))
                    .OfType<T>()
                    .FirstOrDefault();

                var example = new EnumV1Filter<T>
                {
                    Equal = value,
                };

                _ = _container.Add(nameof(example.Equal), example.Equal);
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
