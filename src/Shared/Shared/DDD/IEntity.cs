namespace Shared.DDD;

public interface IEntity
{
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LasstModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
