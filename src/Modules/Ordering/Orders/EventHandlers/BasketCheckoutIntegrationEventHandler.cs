using Basket.Contracts.Basket.Features.GetBasket;
using MassTransit;
using Ordering.Orders.Features.CreateOrder;
using Shared.Messaging.Events;

namespace Ordering.Orders.EventHandlers;

public class BasketCheckoutIntegrationEventHandler(
    ISender sender,
    ILogger<BasketCheckoutIntegrationEventHandler> logger) : IConsumer<BasketCheckoutIntegrationEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutIntegrationEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var createOrderCommand = await MapToCreateOrderCommand(context.Message);
        await sender.Send(createOrderCommand);
    }

    private async Task<CreateOrderCommand> MapToCreateOrderCommand(BasketCheckoutIntegrationEvent message)
    {
        var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.AddressLine, message.Country, message.State, message.ZipCode);
        var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.Cvv, message.PaymentMethod);
        var orderId = Guid.NewGuid();
        var basketResult = await sender.Send(new GetBasketQuery(message.UserName));
        var orderItems = basketResult.ShoppingCart.Items.Select(x => new OrderItemDto(orderId, x.Id, x.Quantity, x.Color, x.Price)).ToList();

        var orderDto = new OrderDto(
            Id: orderId,
            CustomerId: message.CustomerId,
            OrderName: message.UserName,
            ShippingAddress: addressDto,
            BillingAddress: addressDto,
            Payment: paymentDto,
            Items: orderItems
            );

        return new CreateOrderCommand(orderDto);
    }
}
