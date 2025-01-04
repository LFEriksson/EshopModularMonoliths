namespace Basket.Basket.Features.GetBasket;

public record GetBasketResponse(ShoppingCartDto ShoppingCart);
public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Basket/{username}", async (string userName, ISender sender) =>
        {
            var response = await sender.Send(new GetBasketQuery(userName));
            return response.ShoppingCart;
        })
        .Produces<ShoppingCartDto>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Basket")
        .WithDescription("Get Basket")
        .RequireAuthorization();
    }
}