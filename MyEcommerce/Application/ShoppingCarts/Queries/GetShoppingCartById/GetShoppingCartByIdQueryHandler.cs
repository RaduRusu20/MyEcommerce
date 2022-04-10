using Domain.RepositoryPattern;
using Domain.Users;
using MediatR;

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
