using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryPattern
{
    public interface IProductRepository
    {
        public Task CreateProductAsync(Product product, CancellationToken cancellationToken);

        public Task UpdateProductAsync(Product product, Guid id, CancellationToken cancellationToken);

        public Task DeleteProductAsync(Product product, CancellationToken cancellationToken);

        public Task<Product> FindProductByIdAsync(Guid productId, CancellationToken cancellationToken);

        public Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken);

        public Task<List<Product>> GetProductsByCategoryId(Guid categoryId, CancellationToken cancellationToken);   

        public Task<Product> FindProductByNameAsync(string name, CancellationToken cancellationToken);
    }
}
