using Application.Categories.Command;
using Application.Categories.Queries.GetCategories;
using Application.Products.Commands;
using Application.Products.Queries;
using Application.Products.Queries.GetProductByName;
using Application.ShoppingCarts.Commands;
using Application.ShoppingCarts.Commands.AddProductToShoppingCart;
using Application.Users.Command.CreateCustomer;
using Application.Users.Queries.GetCustomerById;
using Application.Users.Queries.GetCustomers;
using Application.Users.Queries.GetUserIdByEmail;
using Domain;
using Domain.RepositoryPattern;
using Infrastructure.DataAccess;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            
            var _diContainer = new ServiceCollection()
                .AddMediatR(typeof(CreateUserCommand))
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IShoppingCartRepository, ShoppingCartRepository>()
                .BuildServiceProvider();

            var _mediator = _diContainer.GetRequiredService<IMediator>();

        }
    }
}