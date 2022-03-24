using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Entities
{
    public class ShoppingCartEntity : BaseEntity
    {
        
        public List<Product> Products { get; set; }

        public ShoppingCartEntity()
        {
            this.Id = Guid.NewGuid();
            this.Products = new List<Product>();
        }
    }
}
