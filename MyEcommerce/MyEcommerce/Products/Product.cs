using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.Products
{
    public class Product
    {
        private int id;
        private string name;
        private string description;
        private float price;
        private float raiting;

        public Product(int id, string name, string description, float price)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
        }

        public override string? ToString()
        {
            return this.name;
        }
    }
}
