using Domain;
using Domain.Products;
using Domain.Roles;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class EcommerceContext : DbContext
    {
       
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-V68LBGAO\SQLEXPRESS;Database=MyEcommerce;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(
        u =>
        {
            u.HasKey(u => u.Id);

            u.Property(u => u.FirstName);
            u.Property(u => u.LastName);
            u.HasIndex(u => u.Email).IsUnique(true);
            u.Property(u => u.Password);
            u.Property(u => u.Phone);
            u.Property(u => u.Adress);
            u.Property(u => u.Role);
        });

            modelBuilder.Entity<Product>(
        p =>
        {
            p.HasKey(p => p.Id);

            p.Property(p => p.Name);
            p.Property(p => p.Description);
            p.Property(p => p.Price);
            p.Property(p => p.Raiting);

        });

            modelBuilder.Entity<Category>(
       c =>
       {
           c.HasKey(c => c.Id);

           c.Property(c => c.Name);
       });

            modelBuilder.Entity<ShoppingCart>(
      sc =>
      {
          sc.HasKey(sc => sc.Id);
          sc.HasOne(sc => sc.User);
      });

            modelBuilder.Entity<ShoppingCartsProducts>()
                .HasKey(scp => new { scp.ShoppingCartId, scp.ProductId });

            modelBuilder.Entity<ShoppingCartsProducts>()
                .HasOne(scp => scp.ShoppingCart)
                .WithMany(scp => scp.Products)
                .HasForeignKey(scp => scp.ShoppingCartId);

            modelBuilder.Entity<ShoppingCartsProducts>()
                .HasOne(scp => scp.Product)
                .WithMany(scp => scp.ShoppingCarts)
                .HasForeignKey(scp => scp.ProductId);
        }
    }
}
