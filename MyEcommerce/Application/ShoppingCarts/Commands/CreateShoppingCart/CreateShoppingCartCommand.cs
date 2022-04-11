using Domain.Users;
using MediatR;

namespace Application.ShoppingCarts.Commands
{
    public class CreateShoppingCartCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
    }
}
