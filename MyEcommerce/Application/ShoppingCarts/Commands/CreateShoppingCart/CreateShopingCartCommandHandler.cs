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
            _repository.CreateShoppingCartAsync(shoppingCart, cancellationToken);
            return Task.FromResult(shoppingCart.Id);
        }
    }
}
