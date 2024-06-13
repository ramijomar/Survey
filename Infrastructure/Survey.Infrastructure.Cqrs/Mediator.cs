using Survey.Infrastructure.Cqrs.Commands;
using Survey.Infrastructure.Cqrs.Queries;

namespace Survey.Infrastructure.Cqrs
{
    public class Mediator : IMediator
    {
        private readonly MediatR.IMediator _mediator;

        public Mediator(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(query, cancellationToken);
        }

        public Task Send(ICommand command, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(command, cancellationToken);
        }

        public Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(command, cancellationToken);
        }
    }
}
