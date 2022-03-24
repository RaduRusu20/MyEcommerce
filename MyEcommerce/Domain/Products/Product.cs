﻿namespace Domain.Products
{
    public class Product
    {

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public float Price { get; }
        public float Raiting { get; }

        public Product(string name, string description, float price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException("description");

            if (price <= 0)
                 throw new ArgumentOutOfRangeException("price");

            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public override string? ToString()
        {
            return this.Name;
        }
    }
}