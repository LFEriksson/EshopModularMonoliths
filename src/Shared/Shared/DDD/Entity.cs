namespace Shared.DDD;

public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; } = default!;
    public DateTime? CreatedAtUTC { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedUTC { get; set; }
    public string? LastModifiedBy { get; set; }
}
