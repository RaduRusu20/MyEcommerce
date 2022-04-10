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
            u.Property(u => u.Email);
            u.Property(u => u.Password);
            u.Property(u => u.Phone);
            u.Property(u => u.Adress);
            u.Property(u => u.Role);
        });

        }
    }
}
