using Domain.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Users
{
    public class ShoppingCart
    {

        public Guid Id { get; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<ShoppingCartsProducts> Products { get; set; }


        internal ShoppingCart()
        {
            this.Id = Guid.NewGuid();
        }

        public override string? ToString()
        {
            return Id.ToString();
        }
    }
}