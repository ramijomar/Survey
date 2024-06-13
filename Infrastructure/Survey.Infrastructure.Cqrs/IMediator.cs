using Survey.Infrastructure.Cqrs.Commands;
using Survey.Infrastructure.Cqrs.Queries;

namespace Survey.Infrastructure.Cqrs
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
        Task Send(ICommand command, CancellationToken cancellationToken = default);
        Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
    }
}
