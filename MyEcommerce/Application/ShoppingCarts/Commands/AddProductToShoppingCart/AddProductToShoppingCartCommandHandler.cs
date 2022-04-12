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
            _repository.AddProductToShoppingCartAsync(command.User, command.Product, cancellationToken);
            return await Task.FromResult(command.User.Id);
        }
    }
}
