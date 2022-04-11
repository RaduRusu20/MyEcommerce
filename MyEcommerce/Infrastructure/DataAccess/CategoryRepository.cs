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
    public class CategoryRepository : ICategoryRepository
    {
        private EcommerceContext ecommerceContext;

        public CategoryRepository()
        {
            ecommerceContext = new EcommerceContext();
        }

        public async Task CreateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            ecommerceContext.Categories.Add(category);
            ecommerceContext.SaveChanges();
        }

        public async Task DeleteCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            ecommerceContext.Categories.Remove(category);
            ecommerceContext.SaveChanges();
        }

        public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return ecommerceContext.Categories.ToList();
        }

        public async Task<Category> FindCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            return ecommerceContext.Categories.SingleOrDefault(x => x.Id == categoryId);
        }

        public async Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> FindIdByNameAsync(string name, CancellationToken cancellationToken)
        {
            return ecommerceContext.Categories.FirstOrDefault(x => x.Name == name).Id;
        }
    }
}
