namespace Survey.Infrastructure.Persistence.Shared
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}
