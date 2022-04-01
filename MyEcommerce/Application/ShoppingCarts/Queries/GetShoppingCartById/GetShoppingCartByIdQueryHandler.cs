using Domain.Customers;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCarts.Queries.GetShoppingCartById
{
    public class GetShoppingCartByIdQueryHandler : IRequestHandler<GetShoppingCartByIdQuery, ShoppingCart>
    {
        private IShoppingCartRepository _repository;

        public GetShoppingCartByIdQueryHandler(IShoppingCartRepository repository)
        { 
            _repository = repository;
        }

        public async Task<ShoppingCart> Handle(GetShoppingCartByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.FindShoppingCartByIdAsync(query.Id, cancellationToken);
        }
    }
}
