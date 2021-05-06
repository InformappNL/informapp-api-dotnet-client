using Informapp.InformSystem.WebApi.Client.Decorators;
using Informapp.InformSystem.WebApi.Client.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.IntegrationTool.Core.Queries
{
    /// <summary>
    /// Validate the provided query
    /// </summary>
    /// <typeparam name="TQuery">The query</typeparam>
    /// <typeparam name="TResult">The result</typeparam>
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
        /// <param name="queryHandler">Injected query handler</param>
        /// <param name="validator">Injected query validator</param>
        public ValidateQueryHandlerDecorator(
            IQueryHandler<TQuery, TResult> queryHandler,
            IValidator<TQuery> validator) : base(queryHandler)
        {
            _queryHandler = queryHandler;

            _validator = validator;
        }

        /// <summary>
        /// Handle validating the provided query
        /// </summary>
        /// <param name="query">The query</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The response</returns>
        public Task<TResult> Handle(TQuery query, CancellationToken cancellationToken)
        {
            Argument.NotNull(query, nameof(query));

            _validator.ValidateObject(query);

            return _queryHandler.Handle(query, cancellationToken);
        }
    }
}
