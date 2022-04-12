using Domain.Users;
using MediatR;

namespace Application.ShoppingCarts.Commands
{
    public class CreateShoppingCartCommand : IRequest<Guid>
    {
        public User User { get; set; }
    }
}
