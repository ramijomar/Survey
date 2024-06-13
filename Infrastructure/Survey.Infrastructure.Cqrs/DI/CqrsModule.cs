using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using System.Reflection;

namespace Survey.Infrastructure.Cqrs.DI
{
    public static class CqrsModule
    {
        public static ContainerBuilder RegisterCqrsModule(this ContainerBuilder builder)
        {
            var assembly = Assembly.GetCallingAssembly();

            var mediatRConfiguration = MediatRConfigurationBuilder.Create(assembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

            builder.RegisterMediatR(mediatRConfiguration);

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            return builder;
        }
    }
}
