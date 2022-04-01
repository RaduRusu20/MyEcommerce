using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryPattern
{
    public interface ICategoryRepository
    {
        public Task CreateCategoryAsync(Category category, CancellationToken cancellationToken);

        public Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken);

        public Task DeleteCategoryAsync(Category category, CancellationToken cancellationToken);

        public Task<Category> FindCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken);

        public Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken);

    }
}
