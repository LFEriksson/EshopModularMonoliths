
namespace Catalog.Products.Models
{
    public record ProductPriceChangedEvent(Product Product) : IDomainEvent
    {
    }
}