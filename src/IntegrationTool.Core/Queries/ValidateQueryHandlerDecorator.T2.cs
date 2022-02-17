using ConnectedDevelopment.InformSystem.WebApi.Client.Decorators;
using ConnectedDevelopment.InformSystem.WebApi.Client.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries
{
    /// <summary>
    /// Validate query handler decorator
    /// </summary>
    /// <typeparam name="TQuery">The type of query</typeparam>
    /// <typeparam name="TResult">The type of result</typeparam>
    public class ValidateQueryHandlerDecorator<TQuery, TResult> :
        Decorator<IQueryHandler<TQuery, TResult>>,
        IQueryHandler<TQuery, TResult>

        where TQuery : class, IQuery<TResult>
        where TResult : class
    {
        private readonly IQueryHandler<TQuery, TResult> _queryHandler;

        private readonly IValidator<TQuery> _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateQueryHandlerDecorator{TQuery, TResult}"/> class
        /// </summary>
        public ValidateQueryHandlerDecorator(
            IQueryHandler<TQuery, TResult> queryHandler,
            IValidator<TQuery> validator) : base(queryHandler)
        {
            _queryHandler = queryHandler;

            _validator = validator;
        }

        /// <inheritdoc/>
        public Task<TResult> Handle(TQuery query, CancellationToken cancellationToken)
        {
            Argument.NotNull(query, nameof(query));

            _validator.ValidateObject(query);

            return _queryHandler.Handle(query, cancellationToken);
        }
    }
}
