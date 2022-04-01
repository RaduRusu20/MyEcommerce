using Domain.Customers;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCarts.Queries
{
    public class GetShoppingCartsQueryHandler : IRequestHandler<GetShoppingCartsQuery, List<ShoppingCart>>
    {
        private IShoppingCartRepository _repository;

        public GetShoppingCartsQueryHandler(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ShoppingCart>> Handle(GetShoppingCartsQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAllShoppingCartAsync(cancellationToken);
        }
    }
}
