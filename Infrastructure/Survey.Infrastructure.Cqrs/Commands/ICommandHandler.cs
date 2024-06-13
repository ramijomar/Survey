namespace Survey.Infrastructure.Cqrs.Commands
{
    public interface ICommandHandler<in TCommand> : MediatR.IRequestHandler<TCommand>
        where TCommand : ICommand
    { }

    public interface ICommandHandler<in TCommand, TResponse> : MediatR.IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    { }
}
