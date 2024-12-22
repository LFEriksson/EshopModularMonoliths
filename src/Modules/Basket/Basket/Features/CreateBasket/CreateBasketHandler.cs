namespace Basket.Basket.Features.CreateBasket;

public record CreateBasketCommand(ShoppingCartDto ShoppingCartDto) : ICommand<CreateBasketResult>;

public record CreateBasketResult(Guid Id);

public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
{
    public CreateBasketCommandValidator()
    {
        RuleFor(x => x.ShoppingCartDto.UserName).NotEmpty().WithMessage("UserName is required.");
    }
}

internal class CreateBasketHandler(IBasketRepository repository) : ICommandHandler<CreateBasketCommand, CreateBasketResult>
{
    public async Task<CreateBasketResult> Handle(CreateBasketCommand command, CancellationToken cancellationToken)
    {
        var shoppingCart = CreateNewBasket(command.ShoppingCartDto);
        await repository.CreateBasket(shoppingCart, cancellationToken);
        return new CreateBasketResult(shoppingCart.Id);
    }

    private ShoppingCart CreateNewBasket(ShoppingCartDto shoppingCartDto)
    {
        var shoppingCart = ShoppingCart.Create(Guid.NewGuid(), shoppingCartDto.UserName);
        shoppingCartDto.Items.ForEach(x => shoppingCart.AddItem(x.ProductId, x.Quantity, x.Price, x.Color, x.ProductName));
        return shoppingCart;
    }
}
