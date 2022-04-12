using Domain.Products;
using Domain.RepositoryPattern;
using Domain.Users;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private EcommerceContext ecommerceContext;

        public ShoppingCartRepository()
        {
            ecommerceContext = new EcommerceContext();
        }

        public async Task CreateShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            ecommerceContext.ShoppingCarts.Add(shoppingCart);
            ecommerceContext.SaveChanges();
        }

        public async Task DeleteShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            ecommerceContext.ShoppingCarts.Remove(shoppingCart);
            ecommerceContext.SaveChanges();
        }

        public async Task<ShoppingCart> FindShoppingCartByIdAsync(Guid shoppingCartId, CancellationToken cancellationToken)
        {
            return ecommerceContext.ShoppingCarts.SingleOrDefault(x => x.Id == shoppingCartId);
        }

        public async Task<List<ShoppingCart>> GetAllShoppingCartAsync(CancellationToken cancellationToken)
        {
            return ecommerceContext.ShoppingCarts
                .Include(sc => sc.Products)
                .ToList();
        }

        public async Task UpdateShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task AddProductToShoppingCartAsync(User user, Product product, CancellationToken cancellationToken)
        {
            var shoppingCartsProducts = new ShoppingCartsProducts
            {
                Product = product,
                ProductId = product.Id,
                ShoppingCart = user.ShoppingCart,
                ShoppingCartId = user.ShoppingCart.Id,
            };

            ecommerceContext.ShoppingCartsProducts.Add(shoppingCartsProducts);
            ecommerceContext.SaveChanges();
        }
    }
}
