using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Entities
{
    public class ProductEntity : BaseEntity
    {
       
        public string Name { get; }
        public string Description { get; }
        public float Price { get; }
        public float Raiting { get; }

        public ProductEntity(string name, string description, float price)
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
