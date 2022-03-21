﻿using System;
using Domain.Admin;
using Domain.Customers;
using Domain.Products;
using Domain.RepositoryPattern;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static Product product = new Product("minge", "albastra", 99.98f);

        static void Main(string[] args)
        {
            int option = 0;
            Admin admin = new Admin();

            admin.Customers = new List<Customer>() {
                new Customer("Radu", "Rusu", "rusu.radu12@yahoo.com", "alexandru123", "0752190344",
                "Arad, Romania, Principala, 1094, 317335"),

                new Customer("Andrei", "Rusu", "rusu.andrei@yahoo.com", "parola@34$", "0749183620",
                "Arad, Romania, Principala, 1094, 317335"),

            };

            //BaseRepository checking if work well

            BaseRepository<Customer> customerRepository = new BaseRepository<Customer>();

            Customer customer1 = new Customer("Radu", "Rusu", "rusu.radu12@yahoo.com", "alexandru123", "0752190344",
                "Arad, Romania, Principala, 1094, 317335");

            Customer customer2 = new Customer("Andrei", "Rusu", "rusu.andrei@yahoo.com", "parola@34$", "0749183620",
                "Arad, Romania, Principala, 1094, 317335");

            customerRepository.Add(customer1);
            customerRepository.Add(customer2);

            
            foreach(Customer customer in customerRepository.items)
            {
                Console.WriteLine(customer);
            }

            customerRepository.Delete(customer1.Id);


            foreach (Customer customer in customerRepository.items)
            {
                Console.WriteLine(customer);
            }

            var customerList = customerRepository.GetAll();

            customerList.ForEach(x => Console.WriteLine(x));

            customerRepository.Add(customer2);
            

            var customer3 = customerRepository.GetById(customer1.Id);

            Console.WriteLine(customer3);

            Console.WriteLine(customerRepository.DateCreatedOn());

            //end checking






            while (true)
            {

                Console.WriteLine("1 -> Add new category.");
                Console.WriteLine("2 -> See all categories.");
                Console.WriteLine("3 -> Delete a  category.");
                Console.WriteLine("4 -> See cutomer list");
                Console.WriteLine("5 -> Add product in a category");
                Console.WriteLine("6 -> See all products in a category");
                Console.WriteLine("7 -> Add to cart");
                Console.WriteLine("8 -> Remove from cart");
                Console.WriteLine("9 -> View Shopping Cart");
                Console.WriteLine("10 -> Checkout");
                Console.WriteLine("11 -> Exit.");

                try
                {
                    Console.WriteLine("Please enter an option: ");
                    option = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Option have to be integer!");
                    goto nextStep;
                   
                }

                switch (option)
                {
                    case 1:
                        addNewCategory(admin);
                        break;
                        
                    case 2:
                        seeCategories(admin);
                        break;

                    case 3:
                        deleteCategory(admin);
                        break;

                    case 4:
                        seeCustomerList(admin);
                        break;
                    case 5:
                        addProduct(admin);
                        break;
                    case 6:
                        seeProductsByCategory(admin);
                        break;
                    case 7:
                        AddToCart(customer1);
                        break;
                    case 8:
                        DeleteFromCart(customer1);
                        break;
                    case 9:
                        SeeProducts(customer1);
                        break;
                    case 10:
                        Checkout(customer1);
                        break;
                    case 11:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                nextStep:

                Console.WriteLine("Continue? y/n");
               string y =  Console.ReadLine();

                if(string.Compare(y, "y") == 0)
                {
                    Console.Clear();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private static void Checkout(Customer customer)
        {
            Console.WriteLine($"Total sum is: {customer.Checkout()}");
        }

        private static void AddToCart(Customer customer)
        {
            customer.AddToCart(product);
        }

        private static void DeleteFromCart(Customer customer)
        {
            customer.DeleteFromCart(product);
        }

        private static void SeeProducts(Customer customer)
        {
            customer.SeeCartProducts();
        }

        private static void seeProductsByCategory(Admin admin)
        {
            string categoryName;

            Console.WriteLine("Category name = ");
            categoryName = Console.ReadLine();

            admin.SeeProductsByCategory(admin.GetCategoryByName(categoryName));
        }

        private static void addProduct(Admin admin)
        {
            string productName, categoryName;
            string description;
            float price;

            Console.Write("Category name = ");
            categoryName = Console.ReadLine();

            Console.Write("Product name = ");
            productName = Console.ReadLine();

            Console.Write("Product description = ");
            description = Console.ReadLine();

            Console.Write("Product price = ");
            price = (float)Convert.ToDouble(Console.ReadLine());


            admin.AddProduct(admin.GetCategoryByName(categoryName), productName, description, price);
        }

        private static void seeCustomerList(Admin admin)
        {
            admin.SeeCustomers();
        }

        private static void seeCategories(Admin admin)
        {
            admin.SeeCategories();
        }

        private static void addNewCategory(Admin admin)
        {
            string categoryName;

            Console.Write("name = ");
            categoryName = Console.ReadLine();

            admin.AddCategory(categoryName);
        }

        private static void deleteCategory(Admin admin)
        {
            string categoryName;

            Console.Write("Category name for deleting: ");
            categoryName = Console.ReadLine();
            admin.DeleteCategory(categoryName);
        }
    }
}