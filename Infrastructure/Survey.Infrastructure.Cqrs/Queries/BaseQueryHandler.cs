namespace Survey.Infrastructure.Cqrs.Queries
{
    public abstract class BaseQueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        protected readonly IMediator Mediator;

        public BaseQueryHandler(IMediator mediator)
        {
            Mediator = mediator;
        }

        public abstract Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken = default);
    }
}
