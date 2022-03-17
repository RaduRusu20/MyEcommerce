using System;
using MyEcommerce.Customers;
using MyEcommerce.Admin;
using MyEcommerce.Products;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            Admin admin = new Admin();
       

            while (true)
            {

                Console.WriteLine("1 -> Add new category.");
                Console.WriteLine("2 -> See all categories.");
                Console.WriteLine("3 -> Delete a  category.");
                Console.WriteLine("4 -> See cutomer list");
                Console.WriteLine("5 -> Add product in a category");
                Console.WriteLine("6 -> See all products in a category");
                Console.WriteLine("7 -> Exit.");

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

        private static void seeProductsByCategory(Admin admin)
        {
            int categoryId;

            Console.WriteLine("Category id = ");
            categoryId = Convert.ToInt32(Console.ReadLine());

            admin.SeeProductsByCategory(admin.GetCategoryById(categoryId));
        }

        private static void addProduct(Admin admin)
        {
            string name;
            string description;
            int id, categoryId;
            float price;

            Console.Write("Category id = ");
            categoryId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Product id = ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Product name = ");
            name = Console.ReadLine();

            Console.Write("Product description = ");
            description = Console.ReadLine();

            Console.Write("Product price = ");
            price = (float)Convert.ToDouble(Console.ReadLine());


            admin.AddProduct(admin.GetCategoryById(categoryId), id, name, description, price);
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
            string name;
            int id;

            Console.Write("name = ");
            name = Console.ReadLine();

            Console.Write("id = ");
            id = Convert.ToInt32(Console.ReadLine());
            admin.AddCategory(id, name);
        }

        private static void deleteCategory(Admin admin)
        {
            int id;

            Console.Write("id for deleting: ");
            id = Convert.ToInt32(Console.ReadLine());
            admin.DeleteCategory(id);
        }
    }
}