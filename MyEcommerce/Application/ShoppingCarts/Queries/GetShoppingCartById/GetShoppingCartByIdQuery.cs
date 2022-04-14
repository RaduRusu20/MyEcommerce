using Domain.Users;
using MediatR;

namespace Application.ShoppingCarts.Queries.GetShoppingCartById
{
    public class GetShoppingCartByIdQuery : IRequest<ShoppingCart>
    {
        public Guid Id { get; set; }
    }
}
