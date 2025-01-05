namespace Ordering.Orders.Dtos;
public record OrderItemDto(
    Guid OrderId,
    Guid ProductId,
    int Quantity,
    string Color,
    decimal Price);