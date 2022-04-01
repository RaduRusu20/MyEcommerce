using Application.Categories.Command;
using Application.Categories.Command.DeleteCategory;
using Application.Categories.Queries.GetCategories;
using Application.Categories.Queries.GetCategoryById;
using Application.Customers.Command.CreateCustomer;
using Application.Customers.Command.DeleteCustomer;
using Application.Customers.Queries.GetCustomerById;
using Application.Customers.Queries.GetCustomers;
using Application.Products.Commands;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Queries;
using Application.Products.Queries.GetProductById;
using Application.ShoppingCarts.Commands;
using Application.ShoppingCarts.Commands.DeleteShoppingCart;
using Application.ShoppingCarts.Queries;
using Application.ShoppingCarts.Queries.GetShoppingCartById;
using Domain.RepositoryPattern;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        // static Product product = new Product("minge", "albastra", 99.98f);

       // private static ServiceProvider _diContainer;
       // private static IMediator _mediator;

        static async Task Main(string[] args)
        {
            /*
            int option = 0;
            Admin admin = new Admin();

          
    

            Customer customer1 = new Customer("Radu", "Rusu", "rusu.radu12@yahoo.com", "alexandru123", "0752190344",
                "Arad, Romania, Principala, 1094, 317335");

            Customer customer2 = new Customer("Andrei", "Rusu", "rusu.andrei@yahoo.com", "parola@34$", "0749183620",
                "Arad, Romania, Principala, 1094, 317335");



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

          //  admin.SeeProductsByCategory(admin.GetCategoryByName(categoryName));
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
           // admin.SeeCustomers();
        }

        private static void seeCategories(Admin admin)
        {
            //admin.SeeCategories();
        }

        private static void addNewCategory(Admin admin)
        {
            string categoryName;

            Console.Write("name = ");
            categoryName = Console.ReadLine();

            admin.CreateCategory(categoryName);
        }

        private static void deleteCategory(Admin admin)
        {
            string categoryName;

            Console.Write("Category name for deleting: ");
            categoryName = Console.ReadLine();

            Category category = new Category(categoryName);

            admin.DeleteCategory(category);
        
            */

            var _diContainer = new ServiceCollection()
                .AddMediatR(typeof(CreateProductCommand))
                .AddScoped<IProductRepository,ProductRepository>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IShoppingCartRepository, ShoppingCartRepository>()
                .BuildServiceProvider();

             var _mediator = _diContainer.GetRequiredService<IMediator>();

            

            var productId = await _mediator.Send(new CreateProductCommand
            {
                Name = "Minge de fotbal",
                Description = "albastra",
                Price = 121.9f
            });

            var productId1 = await _mediator.Send(new CreateProductCommand
            {
                Name = "Minge de rugby",
                Description = "albastra",
                Price = 121.9f
            });

            var productId2 = await _mediator.Send(new CreateProductCommand
            {
                Name = "Minge de volei",
                Description = "albastra",
                Price = 121.9f
            });

            var productList = await _mediator.Send(new GetProductsQuery());

             productList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(" //////////////////////////////////////// ");

            var customerId = await _mediator.Send(new CreateCustomerCommand
            {
                FirstName = "Radu",
                LastName = "Rusu",
                Email = "rusu.radu12@yahoo.com",
                Password = "alexandru",
                Phone = "0752190344",
                Adress = "Str. ",
            });

            var customerId1 = await _mediator.Send(new CreateCustomerCommand
            {
                FirstName = "Andrei",
                LastName = "Rusu",
                Email = "rusu.andrei@yahoo.com",
                Password = "password",
                Phone = "0752190344",
                Adress = "Str. ",
            });

            var customerList = await _mediator.Send(new GetCustomersQuery());

            customerList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(" //////////////////////////////////////// ");

            var customer = await _mediator.Send(new GetCustomerByIdQuery
            {
                Id = customerId,
            });

            Console.WriteLine(customer);

            Console.WriteLine(" //////////////////////////////////////// ");

            var deletedId = await _mediator.Send(new DeleteCustomerCommand
            {
                Customer = customer,
            });

            customerList = await _mediator.Send(new GetCustomersQuery());

            customerList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(" //////////////////////////////////////// ");

            var categoryId = await _mediator.Send(new CreateCategoryCommand
            {
                Name = "mingi de fotbal",
            });

            var categoryId1 = await _mediator.Send(new CreateCategoryCommand
            {
                Name = "mingi de baschet",
            });

            var categoryList = await _mediator.Send(new GetCategoriesQuery());

            categoryList.ForEach(x => Console.WriteLine(x));

            var category = await _mediator.Send(new GetCategoryByIdQuery
            {
                Id = categoryId1,
            });

            Console.WriteLine(category);

            Console.WriteLine(" //////////////////////////////////////// ");

            var removedIdCategory = await _mediator.Send(new DeleteCategoryCommand
            {
                Category = category,
            });

            categoryList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(" //////////////////////////////////////// ");

            var shId = await _mediator.Send(new CreateShoppingCartCommand());
            var shId1 = await _mediator.Send(new CreateShoppingCartCommand());
            var shId2 = await _mediator.Send(new CreateShoppingCartCommand());

            var shList = await _mediator.Send(new GetShoppingCartsQuery());

            shList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(" //////////////////////////////////////// ");

            var shCart = await _mediator.Send(new GetShoppingCartByIdQuery
            {
                Id = shId,
            });

            var shCart1 = await _mediator.Send(new GetShoppingCartByIdQuery
            {
                Id = shId1,
            });

            var removedShId = await _mediator.Send(new DeleteShoppingCartCommand
            {
                ShoppingCart = shCart,
            });

            var removedShId1 = await _mediator.Send(new DeleteShoppingCartCommand
            {
                ShoppingCart = shCart1,
            });

            shList.ForEach(x => Console.WriteLine(x));
        }
    }
}