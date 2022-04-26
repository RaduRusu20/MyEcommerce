using Domain.Products;
using Domain.RepositoryPattern;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private EcommerceContext ecommerceContext;

        public ProductRepository(EcommerceContext _ecommerceContext)
        {
            ecommerceContext = _ecommerceContext;
        }

        public async Task CreateProductAsync(Product product, CancellationToken cancellationToken)
        {
            await ecommerceContext.Products.AddAsync(product);
            await ecommerceContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProductAsync(Product product, CancellationToken cancellationToken)
        {
            ecommerceContext.Products.Remove(product);
            await ecommerceContext.SaveChangesAsync();
        }

        public async Task<Product> FindProductByIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            return await ecommerceContext.Products
                .Include(p => p.Category)
                .Include(p => p.ShoppingCarts)
                .SingleOrDefaultAsync(x => x.Id == productId, cancellationToken);
        }

        public async Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            return await ecommerceContext.Products
                .Include(p => p.Category)
                .Include(p => p.ShoppingCarts)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateProductAsync(Product newProduct, Guid id, CancellationToken cancellationToken)
        {
            var product = await ecommerceContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            newProduct.Id = id;

            if (product != null)
            {
                ecommerceContext.Entry(product).CurrentValues.SetValues(newProduct);
            }

            await ecommerceContext.SaveChangesAsync();
        }

        public async Task<Product> FindProductByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await ecommerceContext.Products
                .Include(p => p.Category)
                .Include(p => p.ShoppingCarts)
                .FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
        }

        public async Task<List<Product>> GetProductsByCategoryId(Guid categoryId, CancellationToken cancellationToken)
        {
            var listOfProducts = await ecommerceContext.Products
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync(cancellationToken);
            return listOfProducts;
        }
    }
}
