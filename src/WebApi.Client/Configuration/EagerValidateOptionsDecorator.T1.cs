using ConnectedDevelopment.InformSystem.WebApi.Client.Arguments;
using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Validators;
using Microsoft.Extensions.Options;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Configuration
{
    /// <summary>
    /// Used to validate retrieved configured <typeparamref name="T"/> instances.
    /// </summary>
    /// <typeparam name="T">The type of options being requested.</typeparam>
    public class EagerValidateOptionsDecorator<T> : Decorator<IOptions<T>>,
        IOptions<T>

        where T : class, new()
    {
        private readonly IOptions<T> _options;

        private readonly IValidator<T> _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EagerValidateOptionsDecorator{T}"/> class and validates options.
        /// </summary>
        public EagerValidateOptionsDecorator(
            IOptions<T> options,
            IValidator<T> validator) : base(options)
        {
            Argument.NotNull(options, nameof(options));
            Argument.NotNull(validator, nameof(validator));

            _options = options;

            _validator = validator;

            var value = _options.Value;

            _validator.ValidateObject(value);
        }

        /// <summary>
        /// The default configured <typeparamref name="T"/> instance
        /// </summary>
        public T Value => _options.Value;
    }
}
