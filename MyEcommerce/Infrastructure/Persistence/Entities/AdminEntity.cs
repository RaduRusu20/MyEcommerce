using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Entities
{
    public class AdminEntity : BaseEntity
    {
        private const String _username = "admin";
        private const string _password = "password";

        public List<Category> Categories { get; }


        public AdminEntity()
        {
            this.Categories = new List<Category>();
        }

        public AdminEntity(List<Category> categories)
        {
            Categories = categories;
        }

        public Category CreateCategory(string name)
        {
            Category category = new Category(name);
            Categories.Add(category);

            return category;
        }

        public Category DeleteCategory(Category category)
        {
            Categories.Remove(category);
            return category;
        }

        public Category GetCategoryByName(string name)
        {
            var category = Categories.Where(x => x.Name == name)
                .FirstOrDefault();

            if (category == null)
            {
                Console.WriteLine("This category doesn't exist!");
            }

            return category;

        }

        public void AddProduct(Category category, string name, string description, float price)
        {
            Product product = new Product(name, description, price);
            category.Products.Add(product);
        }
    }
}
