using Application.Categories.Command;
using Application.Categories.Command.DeleteCategory;
using Application.Categories.Queries.GetCategories;
using Application.Categories.Queries.GetCategoryById;
using Application.Products.Commands;
using Application.Products.Queries;
using Application.ShoppingCarts.Commands;
using Application.ShoppingCarts.Commands.DeleteShoppingCart;
using Application.ShoppingCarts.Queries;
using Application.ShoppingCarts.Queries.GetShoppingCartById;
using Application.Users.Command.CreateCustomer;
using Application.Users.Command.DeleteCustomer;
using Application.Users.Queries.GetCustomerById;
using Application.Users.Queries.GetCustomers;
using Domain.RepositoryPattern;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            /*
            var _diContainer = new ServiceCollection()
                .AddMediatR(typeof(CreateProductCommand))
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<ICustomerRepository, UserRepository>()
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

            var customerId = await _mediator.Send(new CreateUserCommand
            {
                FirstName = "Radu",
                LastName = "Rusu",
                Email = "rusu.radu12@yahoo.com",
                Password = "alexandruAA11111111111111",
                Phone = "0752190344",
                Adress = "Str. ",
                Role = Domain.Roles.Role.Customer,
            }) ;

            var customerId1 = await _mediator.Send(new CreateUserCommand
            {
                FirstName = "Andrei",
                LastName = "Rusu",
                Email = "rusu.andrei@yahoo.com",
                Password = "alexandruAA11111111111111",
                Phone = "0752190344",
                Adress = "Str. ",
                Role = Domain.Roles.Role.Customer,
            });

            var customerList = await _mediator.Send(new GetUsersQuery());

            customerList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(" //////////////////////////////////////// ");

            var customer = await _mediator.Send(new GetUserByIdQuery
            {
                Id = customerId,
            });

            Console.WriteLine(customer);

            Console.WriteLine(" //////////////////////////////////////// ");

            var deletedId = await _mediator.Send(new DeleteUserCommand
            {
                User = customer,
            });

            customerList = await _mediator.Send(new GetUsersQuery());

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
            */


            
        }
    }
}