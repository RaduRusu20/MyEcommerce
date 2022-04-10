using Domain.Products;

namespace Domain.Users
{
    public class ShoppingCart
    {
        public Guid Id { get; }
        public User User { get; set; }
        public List<Product> Products { get; set; }

        internal ShoppingCart(User user)
        {
            this.Id = Guid.NewGuid();
            this.Products = new List<Product>();
            this.User = user;
        }

        public override string? ToString()
        {
            return Id.ToString();
        }
    }
}