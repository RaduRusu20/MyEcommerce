using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCarts.Commands.RemoveProductFromShoppingCart
{
    public class RemoveProductFromShoppingCartCommandHandler : IRequestHandler<RemoveProductFromShoppingCartCommand, Guid>
    {
        private IShoppingCartRepository _repository;

        public RemoveProductFromShoppingCartCommandHandler(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(RemoveProductFromShoppingCartCommand command, CancellationToken cancellationToken)
        {
            await _repository.RemoveProductFromShoppingCartAsync(command.ShoppingCart, command.Product, command.Quantity, cancellationToken);
            return command.Product.Id;
        }
    }
}
