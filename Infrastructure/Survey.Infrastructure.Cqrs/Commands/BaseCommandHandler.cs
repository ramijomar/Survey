namespace Survey.Infrastructure.Cqrs.Commands
{
    public abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        protected readonly IMediator Mediator;

        public BaseCommandHandler(IMediator mediator)
        {
            Mediator = mediator;
        }

        public abstract Task Handle(TCommand command, CancellationToken cancellationToken = default);
    }

    public abstract class BaseCommandHandler<TCommand, TResponse> : ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        protected readonly IMediator Mediator;

        public BaseCommandHandler(IMediator mediator)
        {
            Mediator = mediator;
        }

        public abstract Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}
