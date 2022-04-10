using Domain.Users;
using MediatR;

namespace Application.ShoppingCarts.Commands.DeleteShoppingCart
{
    public class DeleteShoppingCartCommand : IRequest<Guid>
    {
        public ShoppingCart ShoppingCart { get; set; }
    }
}
