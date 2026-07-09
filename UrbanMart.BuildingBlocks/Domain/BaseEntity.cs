namespace UrbanMart.BuildingBlocks.Domain
{
    public abstract class BaseEntity
    {
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }
    }

    public abstract class BaseEntity<TKey> : BaseEntity
    {
        public TKey Id { get; set; } = default!;
    }

    public abstract class BaseEntityWithDelete<TKey> : BaseEntity<TKey>
    {
        public bool IsDeleted { get; set; }
    }
}