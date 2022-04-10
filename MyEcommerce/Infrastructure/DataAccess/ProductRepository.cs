using Domain.Products;
using Domain.RepositoryPattern;
using Infrastructure.Persistence;
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
            return ecommerceContext.Products.SingleOrDefault(x => x.Id == productId);
        }

        public async Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            return ecommerceContext.Products.ToList();
        }

        public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
