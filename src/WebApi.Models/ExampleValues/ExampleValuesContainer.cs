using Informapp.InformSystem.WebApi.Models.Arguments;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    internal class ExampleValuesContainer : IExampleMemberProvider
    {
        private readonly IDictionary<string, object> _dictionary = new Dictionary<string, object>();

        public ExampleValuesContainer Add(string name, object value)
        {
            Argument.NotNullOrEmpty(name, nameof(name));
            Argument.NotNull(value, nameof(value));

            _dictionary.Add(name, value);

            return this;
        }

        public object GetExample(string name)
        {
            Argument.NotNullOrEmpty(name, nameof(name));

            if (_dictionary.TryGetValue(name, out var value) == true)
            {
                return value;
            }

            return null;
        }
    }
}
