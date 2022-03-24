using Domain.Customers;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public string Phone { get; }
        public string Adress { get; }
        public ShoppingCart ShoppingCart { get; }


        public CustomerEntity(string firstName, string lastName, string email, string password, string phone, string adress)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException("firstName");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("email");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password");

            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentNullException("phone");

            if (string.IsNullOrWhiteSpace(adress))
                throw new ArgumentNullException("adress");



            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.Id = Guid.NewGuid();
            this.Adress = adress;
            this.ShoppingCart = new ShoppingCart();
        }

        public void AddToCart(Product product)
        {
            ShoppingCart.Products.Add(product);
        }

        public void DeleteFromCart(Product product)
        {
            ShoppingCart.Products.Remove(product);
        }

        public float Checkout()
        {
            float totalPrice = 0;

            foreach (var product in ShoppingCart.Products)
            {
                totalPrice += product.Price;
            }

            return totalPrice;
        }
        public void SeeCartProducts()
        {
            ShoppingCart.Products.ForEach(x => Console.WriteLine(x));
        }

        public void SortProducts()
        {
            var sortProducts = ShoppingCart.Products.OrderBy(x => x.Name);
            foreach (var product in sortProducts)
            {
                Console.WriteLine(product);
            }
        }

        public void ReverseSortProducts()
        {
            var sortProducts = ShoppingCart.Products.OrderByDescending(x => x.Name);
            foreach (var product in sortProducts)
            {
                Console.WriteLine(product);
            }
        }

        public override String ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
