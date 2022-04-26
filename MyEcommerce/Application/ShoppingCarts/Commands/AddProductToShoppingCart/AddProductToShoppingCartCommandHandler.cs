using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCarts.Commands.AddProductToShoppingCart
{
    public class AddProductToShoppingCartCommandHandler : IRequestHandler<AddProductToShoppingCartCommand, Guid>
    {
        private IShoppingCartRepository _repository;

        public AddProductToShoppingCartCommandHandler(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(AddProductToShoppingCartCommand command, CancellationToken cancellationToken)
        {
             await _repository.AddProductToShoppingCartAsync(command.ShoppingCart, command.Product, command.Quantity, cancellationToken);
              return await Task.FromResult(command.Product.Id);
        }
    }
}
