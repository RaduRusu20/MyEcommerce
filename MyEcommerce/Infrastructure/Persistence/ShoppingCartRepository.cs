using Domain.Customers;
using Domain.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private List<ShoppingCart> _shoppingCarts;

        public ShoppingCartRepository()
        {
            _shoppingCarts = new List<ShoppingCart>();
        }

        public async Task CreateShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            _shoppingCarts.Add(shoppingCart);
        }

        public async Task DeleteShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            _shoppingCarts.Remove(shoppingCart);
        }

        public async Task<ShoppingCart> FindShoppingCartByIdAsync(Guid shoppingCartId, CancellationToken cancellationToken)
        {
            return _shoppingCarts.SingleOrDefault(x => x.Id == shoppingCartId);
        }

        public async Task<List<ShoppingCart>> GetAllShoppingCartAsync(CancellationToken cancellationToken)
        {
            return _shoppingCarts;
        }

        public async Task UpdateShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            int i;

            for (i = 0; i < _shoppingCarts.Count; i++)
            {
                if (_shoppingCarts[i].Id == shoppingCart.Id)
                {
                    _shoppingCarts[i] = shoppingCart;
                }
            }
        }
    }
}
