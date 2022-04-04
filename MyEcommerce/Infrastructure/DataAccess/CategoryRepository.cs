using Domain.Products;
using Domain.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            _categories = new List<Category>();
        }

        public async Task CreateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
             _categories.Add(category);
        }

        public async Task DeleteCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            _categories.Remove(category);
        }

        public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return _categories;
        }

        public async Task<Category> FindCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            return _categories.SingleOrDefault(x => x.Id == categoryId);
        }

        public async Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            int i;

            for(i = 0; i < _categories.Count; i++)
            {
                if(_categories[i].Id == category.Id)
                {
                    _categories[i] = category;
                }
            }
        }
    }
}
