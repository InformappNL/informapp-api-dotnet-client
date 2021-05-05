using Informapp.InformSystem.WebApi.Client.Arguments;
using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Validators;
using Microsoft.Extensions.Options;

namespace Informapp.InformSystem.WebApi.Client.Configuration
{
    /// <summary>
    /// Used to validate retrieved configured <typeparamref name="TOptions"/> instances.
    /// </summary>
    /// <typeparam name="TOptions">The type of options being requested.</typeparam>
    public class ValidateOptionsDecorator<TOptions> : Decorator<IOptions<TOptions>>,
        IOptions<TOptions>

        where TOptions : class, new()
    {
        private readonly IOptions<TOptions> _options;

        private readonly IValidator<TOptions> _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateOptionsDecorator{TOptions}"/> class.
        /// </summary>
        public ValidateOptionsDecorator(
            IOptions<TOptions> options,
            IValidator<TOptions> validator) : base(options)
        {
            Argument.NotNull(options, nameof(options));
            Argument.NotNull(validator, nameof(validator));

            _options = options;

            _validator = validator;
        }

        /// <summary>
        /// The default configured <typeparamref name="TOptions"/> instance
        /// </summary>
        public TOptions Value
        {
            get
            {
                var value = _options.Value;

                _validator.ValidateObject(value);

                return value;
            }
        }
    }
}
