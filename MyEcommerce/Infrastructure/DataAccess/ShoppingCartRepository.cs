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

        public ShoppingCartRepository(EcommerceContext _ecommerceContext)
        {
            ecommerceContext = _ecommerceContext;
        }

        public async Task CreateShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            await ecommerceContext.ShoppingCarts.AddAsync(shoppingCart, cancellationToken);
            await ecommerceContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            ecommerceContext.ShoppingCarts.Remove(shoppingCart);
            await ecommerceContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<ShoppingCart> FindShoppingCartByIdAsync(Guid shoppingCartId, CancellationToken cancellationToken)
        {
            return await ecommerceContext.ShoppingCarts.SingleOrDefaultAsync(x => x.Id == shoppingCartId);
        }

        public async Task<List<ShoppingCart>> GetAllShoppingCartAsync(CancellationToken cancellationToken)
        {
            return await ecommerceContext.ShoppingCarts
                .Include(sc => sc.Products)
                .ToListAsync();
        }

        public async Task UpdateShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task AddProductToShoppingCartAsync(ShoppingCart shoppingCart, Product product, int quantity, CancellationToken cancellationToken)
        {
            if (quantity <= product.AvailableQuantity)
            {
                var shoppingCartsProducts = new ShoppingCartsProducts
                {
                    ProductId = product.Id,
                    ShoppingCartId = shoppingCart.Id,
                    Quantity = quantity,
                };

                product.AvailableQuantity -= quantity;

               
                var newProduct = await ecommerceContext.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
                var updatedProduct = newProduct;
                newProduct.AvailableQuantity = product.AvailableQuantity;
                ecommerceContext.Entry(newProduct).CurrentValues.SetValues(updatedProduct);
               
                ecommerceContext.SaveChanges();
               
                ecommerceContext.ShoppingCartsProducts.Add(shoppingCartsProducts);
                ecommerceContext.SaveChanges();
            }
            else throw new Exception("Insufficient quantity!");
        }

        public async Task RemoveProductFromShoppingCartAsync(ShoppingCart shoppingCart, Product product, int quantity, CancellationToken cancellationToken)
        {
            var item = await ecommerceContext.ShoppingCartsProducts
                .FirstOrDefaultAsync(x => x.ProductId == product.Id && x.ShoppingCartId == shoppingCart.Id, cancellationToken);

            if (quantity == item.Quantity)
            {
                ecommerceContext.ShoppingCartsProducts
                    .Remove(item);
            }
            else
            {
                var updatedItem = item;
                updatedItem.Quantity -= quantity;
                ecommerceContext.Entry(item).CurrentValues.SetValues(updatedItem);
            }

            var newProduct = await ecommerceContext.Products
                   .FirstOrDefaultAsync(x => x.Id == item.ProductId, cancellationToken);

            var updatedProduct = newProduct;
            updatedProduct.AvailableQuantity += quantity;
            ecommerceContext.Entry(newProduct).CurrentValues.SetValues(updatedProduct);

            await ecommerceContext.SaveChangesAsync(cancellationToken);
        }
    }
}
