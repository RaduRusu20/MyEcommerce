using Domain.Products;

namespace Domain.Customers
{
    public class ShoppingCart
    {
        public Guid Id { get; }
        public List<Product> Products { get; set; }

        internal ShoppingCart()
        {
            this.Id = Guid.NewGuid();
            this.Products = new List<Product>();
        }

        public static ShoppingCart CreateShoppingCart()
        {
            return new ShoppingCart();
        }

        public override string? ToString()
        {
            return Id.ToString();
        }
    }
}