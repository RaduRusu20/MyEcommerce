using Domain.RepositoryPattern;
using Domain.Users;
using MediatR;

namespace Application.ShoppingCarts.Commands
{
    public class CreateShopingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, Guid>
    {
        private IShoppingCartRepository _repository;

        public CreateShopingCartCommandHandler(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(CreateShoppingCartCommand command, CancellationToken cancellationToken)
        {
            if (command.User.Role == Domain.Roles.Role.Customer)
            {
                var shoppingCart = new ShoppingCart();
                shoppingCart.UserId = command.User.Id;
                _repository.CreateShoppingCartAsync(shoppingCart, cancellationToken);

                return Task.FromResult(shoppingCart.Id);
            }
            else throw new Exception("You have to be customer in order to create a shopping cart!");
        }
    }
}
