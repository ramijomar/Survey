namespace Survey.Infrastructure.Persistence.Shared
{
    public abstract class BaseEntity : Entity, IBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
