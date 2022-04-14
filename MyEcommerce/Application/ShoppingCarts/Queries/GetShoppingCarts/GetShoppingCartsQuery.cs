using Domain.Users;
using MediatR;

namespace Application.ShoppingCarts.Queries
{
    public class GetShoppingCartsQuery : IRequest<List<ShoppingCart>>
    {
    }
}
