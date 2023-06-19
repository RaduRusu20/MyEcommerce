using Application.Products.Commands;
using Domain.RepositoryPattern;
using Infrastructure.DataAccess;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(CreateProductCommand));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<EcommerceContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Remote")));


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.


//if (app.Environment.IsDevelopment()) // this works only on local host
//{
    app.UseSwagger();
 app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyEcommerce API v1");
    c.RoutePrefix = String.Empty;
});
//}

app.UseHttpsRedirection();

app.UseCors(builder => builder.WithOrigins("*")
                              .AllowAnyMethod()
                              .AllowAnyHeader());
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
