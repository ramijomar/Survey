namespace Survey.Infrastructure.Cqrs.Queries
{
    public interface IQuery<out TResponse> : MediatR.IRequest<TResponse> { }
}
