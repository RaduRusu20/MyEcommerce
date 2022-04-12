using Application.Categories.Queries.GetCategories;
using Application.Products.Commands;
using Application.Products.Queries;
using Application.Products.Queries.GetProductByName;
using Application.ShoppingCarts.Commands;
using Application.ShoppingCarts.Commands.AddProductToShoppingCart;
using Application.Users.Command.CreateCustomer;
using Application.Users.Queries.GetCustomers;
using Application.Users.Queries.GetUserIdByEmail;
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

            
            var _diContainer = new ServiceCollection()
                .AddMediatR(typeof(CreateProductCommand))
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IShoppingCartRepository, ShoppingCartRepository>()
                .BuildServiceProvider();

            var _mediator = _diContainer.GetRequiredService<IMediator>();

            var user = await _mediator.Send(new GetUserByEmailQuery
            {
                Email = "rusu.radu12@yahoo.com"
            });

            var product = await _mediator.Send(new GetProductByNameQuery
            {
                Name = "Puma NEYMAR JR",
            });

            var product1 = await _mediator.Send(new GetProductByNameQuery
            {
                Name = "HAMMER CleverFold",
            });

            await _mediator.Send(new AddProductToShoppingCartCommand
            {
                User = user,
                Product = product,
            });

            //await _mediator.Send(new AddProductToShoppingCartCommand
            //{
               // User = user,
               // Product = product1,
           // });

            Console.ReadKey();

        }
    }
}