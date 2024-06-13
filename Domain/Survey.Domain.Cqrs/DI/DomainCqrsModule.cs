using Autofac;
using Survey.Infrastructure.Cqrs.DI;

namespace Survey.Domain.Cqrs.DI
{
    public static class DomainCqrsModule
    {
        public static ContainerBuilder RegisterDomainCqrsModule(this ContainerBuilder builder)
        {
            builder.RegisterCqrsModule();

            return builder;
        }
    }
}
