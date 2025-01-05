namespace Shared.DDD;

public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}

public interface IEntity
{
    public DateTime? CreatedAtUTC { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedUTC { get; set; }
    public string? LastModifiedBy { get; set; }
}