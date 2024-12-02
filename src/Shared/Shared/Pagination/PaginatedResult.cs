namespace Shared.Pagination;

public class PaginatedResult<TEntity>
    (int pageIndex, int pageSize, long totalItems, IEnumerable<TEntity> items) where TEntity : class
{
    public int PageIndex { get; } = pageIndex;
    public int PageSize { get; } = pageSize;
    public long TotalItems { get; } = totalItems;
    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
    public IEnumerable<TEntity> Items { get; } = items;

}
