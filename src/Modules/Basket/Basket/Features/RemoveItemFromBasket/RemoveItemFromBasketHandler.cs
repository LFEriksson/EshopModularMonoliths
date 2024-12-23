namespace Basket.Basket.Features.RemoveItemFromBasket;

public record RemoveItemFromBasketCommand(string UserName, Guid ProductId) : ICommand<RemoveItemFromBasketResult>;

public record RemoveItemFromBasketResult(Guid id);

internal class RemoveItemFromBasketCommandValidator : AbstractValidator<RemoveItemFromBasketCommand>
{
    public RemoveItemFromBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required");
    }
}

internal class RemoveItemFromBasketHandler(IBasketRepository repository) : ICommandHandler<RemoveItemFromBasketCommand, RemoveItemFromBasketResult>
{
    public async Task<RemoveItemFromBasketResult> Handle(RemoveItemFromBasketCommand command, CancellationToken cancellationToken)
    {
        var shoppingCart = await repository.GetBasket(command.UserName, false, cancellationToken).ConfigureAwait(false);
        shoppingCart.RemoveItem(command.ProductId);
        await repository.SaveChangesAsync(command.UserName, cancellationToken);
        return new RemoveItemFromBasketResult(shoppingCart.Id);
    }
}