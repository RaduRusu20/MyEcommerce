using Domain.Customers;
using Domain.Products;

namespace Domain.Admin
{
    public class Admin
    {
        private const String _username = "admin";
        private const string _password = "password";

        

        public Category CreateCategory(string name)
        {
            return new Category(name);
        }


        public void AddProduct(Category category, string name, string description, float price)
        {
            Product product = new Product(name, description, price);
            category.Products.Add(product);
        }
    }
}
