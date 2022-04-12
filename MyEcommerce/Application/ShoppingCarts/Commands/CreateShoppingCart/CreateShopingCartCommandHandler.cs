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
            var shoppingCart = new ShoppingCart();
            shoppingCart.UserId = command.User.Id;
            _repository.CreateShoppingCartAsync(shoppingCart, cancellationToken);

            return Task.FromResult(shoppingCart.Id);
        }
    }
}
