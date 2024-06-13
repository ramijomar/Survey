using Autofac;
using Survey.Domain.Repositories.Questionnaires;
using Survey.Infrastructure.Persistence.DbContexts;
using Survey.Infrastructure.Persistence.Repositories.Questionnaires;

namespace Survey.Infrastructure.Persistence.DI
{
    public static class PersistenceModule
    {
        public static ContainerBuilder RegisterPersistenceModule(this ContainerBuilder builder)
        {
            RegisterDatabaseContext(builder);

            RegisterRepositories(builder);

            return builder;
        }

        private static void RegisterDatabaseContext(ContainerBuilder builder)
        {
            builder.RegisterType<SurveyDbContext>()
                .As<ISurveyDbContext>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<QuestionnaireReadRepository>().As<IQuestionnaireReadRepository>();
        }
    }
}
