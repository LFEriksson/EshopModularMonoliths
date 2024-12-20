namespace Basket.Basket.Features.RemoveItemFromBasket;

public record RemoveItemFromBasketRequest(string UserName, Guid ItemId);

public record RemoveItemFromBasketResponse(Guid id);

internal class RemoveItemFromBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Basket/{username}/items/{itemId}", async ([FromRoute] string userName, [FromRoute] Guid itemId, ISender sender) =>
        {
            var command = new RemoveItemFromBasketCommand(userName, itemId);
            var result = await sender.Send(command);
            var response = result.Adapt<RemoveItemFromBasketResponse>();
            return Results.Created($"/Basket/{response.id}", response);
        })
        .Produces<RemoveItemFromBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Remove Item From Basket")
        .WithDescription("Remove Item From Basket");
    }
}