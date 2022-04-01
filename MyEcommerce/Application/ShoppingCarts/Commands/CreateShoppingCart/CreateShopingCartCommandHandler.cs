using Domain.Customers;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var shoppingCart = ShoppingCart.CreateShoppingCart();
            _repository.CreateShoppingCartAsync(shoppingCart, cancellationToken);
            return Task.FromResult(shoppingCart.Id);
        }
    }
}
