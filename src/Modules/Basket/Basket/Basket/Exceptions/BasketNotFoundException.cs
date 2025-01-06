using Shared.Exceptions;

namespace Basket.Basket.Exceptions;

public class BasketNotFoundException(string userName)
    : NotFoundException("ShoppingCasrt", userName)
{
}
