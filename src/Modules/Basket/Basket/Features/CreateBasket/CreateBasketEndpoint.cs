namespace Basket.Basket.Features.CreateBasket;

public record CreateBasketRequeest(ShoppingCartDto ShoppingCartDto);

public record CreateBasketRespose(Guid Id);

public class CreateBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (CreateBasketRequeest request, ISender sender) =>
        {
            var command = request.Adapt<CreateBasketCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateBasketRespose>();
            return Results.Created($"/basket/{response.Id}", response);
        })
        .Produces<CreateBasketRespose>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Basket")
        .WithDescription("Create Basket")
        .RequireAuthorization();
    }
}
