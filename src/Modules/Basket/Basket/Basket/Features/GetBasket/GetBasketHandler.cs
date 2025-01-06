namespace Basket.Basket.Features.GetBasket;

internal class GetBasketHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasket(query.UserName, true, cancellationToken);
        var basketDto = basket.Adapt<ShoppingCartDto>();
        return new GetBasketResult(basketDto);
    }
}

