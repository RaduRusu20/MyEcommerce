using Domain.Products;
using Domain.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>();
        }

        public async Task CreateProductAsync(Product product, CancellationToken cancellationToken)
        {
            _products.Add(product);
        }

        public async Task DeleteProductAsync(Product product, CancellationToken cancellationToken)
        {
            _products.Remove(product);
        }

        public async Task<Product> FindProductByIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            return _products.SingleOrDefault(x => x.Id == productId);
        }

        public async Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            return _products;
        }

        public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken)
        {
            int i;

            for (i = 0; i < _products.Count; i++)
            {
                if (_products[i].Id == product.Id)
                {
                    _products[i] = product;
                }
            }
        }
    }
}
