namespace Survey.Infrastructure.Cqrs.Commands
{
    public interface ICommand : MediatR.IRequest { }
    public interface ICommand<out TResponse> : MediatR.IRequest<TResponse> { }
}
