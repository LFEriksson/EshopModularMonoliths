namespace Basket.Basket.Features.AddItemIntoBasket;

public record AddItemIntoBasketCommand(string UserName, ShoppingCartItemDto ShoppingCartItemDto)
    : ICommand<AddItemIntoBasketResult>;

public record AddItemIntoBasketResult(Guid id);

public class AddItemIntoBasketCommandValidator : AbstractValidator<AddItemIntoBasketCommand>
{
    public AddItemIntoBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        RuleFor(x => x.ShoppingCartItemDto.ProductId).NotEmpty().WithMessage("ProductId is required");
        RuleFor(x => x.ShoppingCartItemDto.Quantity).GreaterThan(0).WithMessage("Quantity should be greater than 0");
    }
}


internal class AddItemIntoBasketHandler(IBasketRepository repository) : ICommandHandler<AddItemIntoBasketCommand, AddItemIntoBasketResult>
{
    public async Task<AddItemIntoBasketResult> Handle(AddItemIntoBasketCommand command, CancellationToken cancellationToken)
    {
        var shoppingCart = await repository.GetBasket(command.UserName, false, cancellationToken);

        shoppingCart.AddItem(
            command.ShoppingCartItemDto.ProductId,
            command.ShoppingCartItemDto.Quantity,
            command.ShoppingCartItemDto.Price,
            command.ShoppingCartItemDto.Color,
            command.ShoppingCartItemDto.ProductName);

        await repository.SaveChangesAsync(cancellationToken);

        return new AddItemIntoBasketResult(shoppingCart.Id);
    }
}
