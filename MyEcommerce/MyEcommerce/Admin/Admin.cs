using MyEcommerce.Customers;
using MyEcommerce.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.Admin
{
    public class Admin
    {
        private const string username = "admin";
        private const string password = "password";
        private List<Category> categories;
        private List<Customer> customers;


        public Admin()
        {
            this.categories = new List<Category>();
            this.customers = new List<Customer>();
        }

        public List<Category> Categories { get { return categories; } }

        public void AddCategory(int id, string name)
        {
            Category category = new Category(id, name);
            categories.Add(category);
        }

        public void DeleteCategory(int id)
        {

            int sw = 0;

            for (int i = 0; i < categories.Count && sw == 0; i++)
            {
                if (categories[i].Id == id)
                 {
                     categories.Remove(categories[i]);
                     sw = 1;
                  }
             }

            if(sw == 0)
            {
                Console.WriteLine("This id doesn't exist!!!");
            }
          
        }

        public void SeeCategories()
        {
            foreach(Category c in categories)
            {
                Console.WriteLine(c);
            }
        }

        public void SeeCustomers()
        {
            foreach(Customer c in customers)
            {
                Console.WriteLine(c);
            }
        }

        public Category GetCategoryById(int id)
        {
            foreach(Category category in categories)
            {
                if(category.Id == id)
                {
                    return category;
                }
            }

            return null;
        }

        public void AddProduct(Category category, int id, string name, string description, float price)
        {
            Product product = new Product(id, name, description, price);
            category.Products.Add(product);
        }

        public void SeeProductsByCategory(Category category)
        {
            foreach(Product product in category.Products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
