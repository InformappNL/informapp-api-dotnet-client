using System;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    internal class ExampleValuesContainer : IExampleMemberProvider
    {
        private readonly IDictionary<string, object> _dictionary = new Dictionary<string, object>();

        public ExampleValuesContainer Add(string name, object value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(name) == true)
            {
                throw new ArgumentException("Must not be empty", nameof(name));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _dictionary.Add(name, value);

            return this;
        }

        public object GetExample(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(name) == true)
            {
                throw new ArgumentException("Must not be empty", nameof(name));
            }

            if (_dictionary.TryGetValue(name, out var value) == true)
            {
                return value;
            }

            return null;
        }
    }
}
