namespace Basket.Basket.Features.AddItemIntoBasket;

public record AddItemIntoBasketRequest(string UserName, ShoppingCartItemDto Item);

public record AddItemIntoBasketResponse(Guid id);

internal class AddItemIntoBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Basket/{username}/items", async ([FromRoute] string userName, [FromBody] AddItemIntoBasketRequest request, ISender sender) =>
        {
            var command = new AddItemIntoBasketCommand(userName, request.Item);
            var result = await sender.Send(command);
            var response = result.Adapt<AddItemIntoBasketResponse>();

            return Results.Created($"/Basket/{response.id}", response);
        })
        .Produces<AddItemIntoBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Add Item Into Basket")
        .WithDescription("Add Item Into Basket");
    }
}
