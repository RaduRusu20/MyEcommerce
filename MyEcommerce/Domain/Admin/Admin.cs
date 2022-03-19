using Domain.Customers;
using Domain.Products;

namespace Domain.Admin
{
    public class Admin
    {
        private const string username = "admin";
        private const string password = "password";

        public List<Category> Categories { get; }
        public List<Customer> Customers { get; set; }


        public Admin()
        {
            this.Categories = new List<Category>();
            this.Customers = new List<Customer>();
        }


        public void AddCategory(string name)
        {
            Category category = new Category(name);
            Categories.Add(category);
        }

        public void DeleteCategory(string name)
        {

            var categoryTbd = Categories.Where(x => x.Name == name)
                .SingleOrDefault();

            if (categoryTbd == null)
            {
                Console.WriteLine("This id doesn't exist!");
                return;
            }

            Categories.Remove(categoryTbd);

        }

        public void SeeCategories()
        {
            foreach (Category c in Categories)
            {
                Console.WriteLine(c);
            }
        }

        public void SeeCustomers()
        {
            foreach (Customer c in Customers)
            {
                Console.WriteLine(c);
            }
        }

        public Category GetCategoryByName(string name)
        {
            var category =  Categories.Where(x => x.Name == name)
                .FirstOrDefault();

            if (category == null)
            {
                Console.WriteLine("This category doesn't exist!");
                return null;
            }

            return category;
                
        }

        public void AddProduct(Category category, string name, string description, float price)
        {
            Product product = new Product(name, description, price);
            category.Products.Add(product);
        }

        public void SeeProductsByCategory(Category category)
        {
            foreach (Product product in category.Products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
