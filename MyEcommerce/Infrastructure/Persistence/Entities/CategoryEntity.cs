using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public CategoryEntity(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            this.Id = Guid.NewGuid();
            this.Name = name;
            Products = new List<Product>();
        }


        public override string? ToString()
        {
            return this.Name + ", id = " + this.Id;
        }
    }
}
