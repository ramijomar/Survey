namespace Survey.Infrastructure.Cqrs.Queries
{
    public interface IQueryHandler<in TQuery, TResponse> : MediatR.IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    { }
}
