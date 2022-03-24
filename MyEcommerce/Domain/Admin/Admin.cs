﻿using Domain.Customers;
using Domain.Products;

namespace Domain.Admin
{
    public class Admin
    {
        private const String _username = "admin";
        private const string _password = "password";

        
        public List<Category> Categories { get; }


        public Admin()
        {
            this.Categories = new List<Category>();
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
            var category =  Categories.Where(x => x.Name == name)
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
