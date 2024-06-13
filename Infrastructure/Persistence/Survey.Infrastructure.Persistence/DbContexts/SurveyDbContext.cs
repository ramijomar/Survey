using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Survey.Infrastructure.Persistence.Entities;
using Survey.Infrastructure.Persistence.Shared;

namespace Survey.Infrastructure.Persistence.DbContexts
{
    public class SurveyDbContext : DbContext, ISurveyDbContext
    {
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options)
            : base(options) { }

        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var foreigneKey in entityType.GetForeignKeys())
                {
                    foreigneKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void BeforeSaveChanges()
        {
            var changedEntries = ChangeTracker.Entries()
                .Where(e => (e.Entity is IEntity
                    || e.Entity is IBaseEntity)
                && (e.State == EntityState.Added
                    || e.State == EntityState.Modified
                    || e.State == EntityState.Deleted))
                .ToArray();

            if (!changedEntries.Any())
            {
                return;
            }

            for (int i = 0; i < changedEntries.Length; i++)
            {
                var entry = changedEntries[i];

                SetBaseEntityProperties(entry);
            }
        }

        private static void SetBaseEntityProperties(EntityEntry entry)
        {
            if (!(entry.Entity is IEntity or IBaseEntity)
                || (entry.State != EntityState.Added && entry.State != EntityState.Modified))
            {
                return;
            }

            var now = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                if (entry.Entity is IEntity)
                {
                    var idProperty = entry.Property(nameof(IEntity.Id));

                    if (idProperty.CurrentValue == null || (Guid)idProperty.CurrentValue == Guid.Empty)
                    {
                        idProperty.CurrentValue = Guid.NewGuid();
                    }
                }

                if (entry.Entity is not IBaseEntity)
                {
                    return;
                }

                entry.Property(nameof(IBaseEntity.CreatedAt)).CurrentValue = now;
            }

            if (entry.Entity is not IBaseEntity)
            {
                return;
            }

            entry.Property(nameof(IBaseEntity.UpdatedAt)).CurrentValue = now;
        }
    }
}
