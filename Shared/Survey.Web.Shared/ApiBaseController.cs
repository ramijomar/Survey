using Microsoft.AspNetCore.Mvc;
using Survey.Infrastructure.Cqrs;
using Survey.Infrastructure.Cqrs.Commands;
using Survey.Infrastructure.Cqrs.Queries;

namespace Survey.Web.Shared
{
    [ApiController]
    public abstract class ApiBaseController
    {
        protected readonly IMediator Mediator;

        protected ApiBaseController(IServiceProvider serviceProvider)
        {
            Mediator = serviceProvider.GetService(typeof(IMediator)) as IMediator;
        }

        [NonAction]
        protected Task Send(ICommand command, CancellationToken cancellationToken = default)
        {
            return Mediator.Send(command, cancellationToken);
        }

        [NonAction]
        protected Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
        {
            return Mediator.Send(command, cancellationToken);
        }

        [NonAction]
        protected Task<TResponse> Send<TResponse>(IQuery<TResponse> command, CancellationToken cancellationToken = default)
        {
            return Mediator.Send(command, cancellationToken);
        }
    }
}
