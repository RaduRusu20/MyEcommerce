using Domain.Customers;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Domain.UnitTests
{
    public class CustomerMethodsTests
    {
        //tests for AddToCart method
        [Fact]
        public void AddToCart2Products()
        {
            var customer =  new Customer("Radu", "Rusu", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa");

            customer.AddToCart(new Product("minge de fotbal", "rosie", 99.9f));
            customer.AddToCart(new Product("minge de fotbal", "albastra", 79.9f));

            Assert.Equal(2, customer.ShoppingCart.Products.Count);
        }

        [Fact]
        public void AddToCart0Products()
        {
            var customer = new Customer("Radu", "Rusu", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa");

            Assert.Equal(0, customer.ShoppingCart.Products.Count);
        }

        [Fact]
        public void AddToCartALotOfProducts()
        {
            var customer = new Customer("Radu", "Rusu", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa");

            for(int i = 0; i < 100000; i++)
            {
                customer.AddToCart(new Product("minge de fotbal", "rosie", 99.9f));
            }

            Assert.Equal(100000, customer.ShoppingCart.Products.Count);
        }

        //tests for DeleteFromCart method
        [Fact]
        public void DeleteFromCart()
        {
            var customer = new Customer("Radu", "Rusu", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa");

            Product product = new Product("minge de fotbal", "rosie", 99.9f);
            customer.AddToCart(product);
            Product product1 = new Product("minge de fotbal", "rosie", 99.9f);
            customer.AddToCart(product1);

            customer.DeleteFromCart(product);

            Assert.Equal(1, customer.ShoppingCart.Products.Count);
        }

        [Fact]
        public void DeleteFromEmptyCart()
        {
            var customer = new Customer("Radu", "Rusu", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa");

            Product product = new Product("minge de fotbal", "rosie", 99.9f);
            customer.DeleteFromCart(product);

            Assert.Equal(0, customer.ShoppingCart.Products.Count);
        }

        //tests for Checkout method
        [Fact]
        public void Checkout2Products()
        {
            var customer = new Customer("Radu", "Rusu", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa");

            Product product = new Product("minge de fotbal", "rosie", 99.9f);
            customer.AddToCart(product);
            Product product1 = new Product("minge de fotbal", "rosie", 99.9f);
            customer.AddToCart(product1);


            Assert.Equal(199.8f, customer.Checkout());
        }

        [Fact]
        public void Checkout0Products()
        {
            var customer = new Customer("Radu", "Rusu", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa");

            Assert.Equal(0f, customer.Checkout());
        }

        [Fact]
        public void CheckoutALotOfProducts()
        {
            var customer = new Customer("Radu", "Rusu", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa");

            for (int i = 0; i < 100000; i++)
            {
                customer.AddToCart(new Product("minge de fotbal", "rosie", 50f));
            }

            Assert.Equal(5000000f, customer.Checkout());
        }
    }
}
