using Application.Categories.Queries.GetCategoryIdByName;
using Application.Products.Commands;
using Application.ShoppingCarts.Commands;
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

            var idUsr1 = await _mediator.Send(new GetUserIdByEmailQuery
            {
                Email = "rusu.radu12@yahoo.com",
            });

       
            await _mediator.Send(new CreateShoppingCartCommand
            {
                UserId = idUsr1,
            });
            

        }
    }
}