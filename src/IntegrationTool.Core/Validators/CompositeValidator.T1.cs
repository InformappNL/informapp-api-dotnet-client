using Informapp.InformSystem.WebApi.Client.Validators;
using System.Collections.Generic;

namespace Informapp.InformSystem.IntegrationTool.Core.Validators
{
    /// <summary>
    /// Composite validator class
    /// </summary>
    /// <typeparam name="T">Type to be validated</typeparam>
    public class CompositeValidator<T> : IValidator<T>
        where T : class
    {
        private readonly IReadOnlyList<IValidator<T>> _validators;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeValidator{T}"/> class
        /// </summary>
        /// <param name="validators">Injected validator</param>
        public CompositeValidator(
            IReadOnlyList<IValidator<T>> validators)
        {
            Argument.NotNullOrEmpty(validators, nameof(validators));

            _validators = validators;
        }

        /// <summary>
        /// Goes through the list of validators and executes the validation
        /// </summary>
        /// <param name="instance">The instance</param>
        public void ValidateObject(T instance)
        {
            Argument.NotNull(instance, nameof(instance));

            foreach (var validator in _validators)
            {
                validator.ValidateObject(instance);
            }
        }
    }
}
