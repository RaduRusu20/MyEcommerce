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
using Domain.Products;
using Domain.RepositoryPattern;
using Domain.Users;
using Infrastructure.DataAccess;
using Infrastructure.Persistence;
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
                .AddScoped<ICustomerRepository, UserRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IShoppingCartRepository, ShoppingCartRepository>()
                .BuildServiceProvider();

            var _mediator = _diContainer.GetRequiredService<IMediator>();
            
            var usersList = await _mediator.Send(new GetUsersQuery());
            
        }
    }
}