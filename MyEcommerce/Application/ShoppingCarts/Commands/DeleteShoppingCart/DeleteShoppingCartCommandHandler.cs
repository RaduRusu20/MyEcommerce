using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCarts.Commands.DeleteShoppingCart
{
    public class DeleteShoppingCartCommandHandler : IRequestHandler<DeleteShoppingCartCommand, Guid>
    {
        private IShoppingCartRepository _repository;

        public DeleteShoppingCartCommandHandler(IShoppingCartRepository repository)
        {
            _repository = repository;   
        }

        public Task<Guid> Handle(DeleteShoppingCartCommand command, CancellationToken cancellationToken)
        {
           _repository.DeleteShoppingCartAsync(command.ShoppingCart, cancellationToken);
            return Task.FromResult(command.ShoppingCart.Id);
        }
    }
}
