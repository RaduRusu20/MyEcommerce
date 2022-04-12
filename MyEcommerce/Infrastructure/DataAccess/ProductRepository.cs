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

        public ProductRepository()
        {
            ecommerceContext = new EcommerceContext();
        }

        public async Task CreateProductAsync(Product product, CancellationToken cancellationToken)
        {
            ecommerceContext.Products.Add(product);
            ecommerceContext.SaveChanges();
        }

        public async Task DeleteProductAsync(Product product, CancellationToken cancellationToken)
        {
            ecommerceContext.Products.Remove(product);
            ecommerceContext.SaveChanges();
        }

        public async Task<Product> FindProductByIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            return ecommerceContext.Products
                .Include(p => p.Category)
                .Include(p => p.ShoppingCarts)
                .SingleOrDefault(x => x.Id == productId);
        }

        public async Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            return ecommerceContext.Products
                .Include(p => p.Category)
                .Include(p => p.ShoppingCarts)
                .ToList();
        }

        public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> FindProductByNameAsync(string name, CancellationToken cancellationToken)
        {
            return ecommerceContext.Products
                .Include(p => p.Category)
                .Include(p => p.ShoppingCarts)
                .FirstOrDefault(x => x.Name == name);
        }
    }
}
